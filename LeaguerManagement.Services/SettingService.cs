using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories;
using Microsoft.Extensions.Options;
using NLog;

namespace LeaguerManagement.Services
{
    public class SettingService : BaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private IRepository<Role> _roleRepository;
        private IRepository<AccessControl> _accessControlRepository;
        private IRepository<AccessOfRole> _accessOfRoleRepository;
        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<ChangeOfficialDocumentType> _changeOfficialDocumentType;
        private IRepository<ChangeOfficialDocument> _changeOfficialDocument;

        public SettingService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper,
            ILogger logger, IOptionsSnapshot<GlobalSettings> settings) : base(unitOfWorkFactory, settings)
        {

            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LookupModel> GetLookup(string keys)
        {
            using var unitOfWork = UnitOfWorkFactory();
            var keyArray = keys?.Split(',');
            var result = new LookupModel();

            if (string.IsNullOrEmpty(keys))
            {
                return new LookupModel
                {
                    Roles = (await unitOfWork.Repository<Role>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Units = (await unitOfWork.Repository<Unit>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Statuses = (await unitOfWork.Repository<Status>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    ChangeOfficialDocumentTypes = (await unitOfWork.Repository<ChangeOfficialDocumentType>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Ratings = (await unitOfWork.Repository<Rating>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                };
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Roles.ToString()))
            {
                result.Roles = (await unitOfWork.Repository<Role>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Units.ToString()))
            {
                result.Units = (await unitOfWork.Repository<Unit>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Statuses.ToString()))
            {
                result.Statuses = (await unitOfWork.Repository<Status>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.ChangeOfficialDocumentTypes.ToString()))
            {
                result.ChangeOfficialDocumentTypes = (await unitOfWork.Repository<ChangeOfficialDocumentType>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.ChangeOfficialDocuments.ToString()))
            {
                result.ChangeOfficialDocuments = _mapper.Map<IList<ChangeOfficialDocumentModel>>(await unitOfWork.Repository<ChangeOfficialDocument>().GetAllAsync()).ToList();
            }

            return result;
        }

        #region Role

        public async Task<LoadResult> GetRoles(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _roleRepository = unitOfWork.Repository<Role>();

            var owners = await _roleRepository.GetRoles();
            return LoadCustom(owners, loadOptions);
        }

        public async Task<bool> AddRole(RoleModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _roleRepository = unitOfWork.Repository<Role>();
            _accessOfRoleRepository = unitOfWork.Repository<AccessOfRole>();

            try
            {
                if (await _roleRepository.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Vai trò"));

                if (input.AccessControlIds.Any())
                    unitOfWork.BeginTransaction();
                // ADD ROLE
                var role = new Role { Name = input.Name.Trim() };
                await _roleRepository.InsertAsync(role);
                // ADD ACCESS OF ROLE
                if (input.AccessControlIds.Any())
                {
                    await _accessOfRoleRepository.InsertRangeAsync(input.AccessControlIds.Select(a => new AccessOfRole
                    {
                        RoleId = role.Id,
                        AccessControlId = a,
                        IsActivated = true
                    }).ToList());
                    unitOfWork.CommitTransaction();
                }
                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateRole(RoleModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _roleRepository = unitOfWork.Repository<Role>();
            _accessOfRoleRepository = unitOfWork.Repository<AccessOfRole>();
            try
            {
                if (await _roleRepository.IsDuplicated(input.Id, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Vai trò"));

                unitOfWork.BeginTransaction();
                // UPDATE ROLE
                var role = await GetOrThrow(_roleRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Vai trò"));
                role.Name = input.Name.Trim();
                // UPDATE ACCESSES OF ROLE
                var accessesOfRole = await _accessOfRoleRepository.GetByRole(role.Id);
                // EXISTING
                var existingIds = accessesOfRole.Select(_ => _.AccessControlId);
                //// remove in updating
                foreach (var access in accessesOfRole.Where(_ => !input.AccessControlIds.Contains(_.AccessControlId) && _.IsActivated))
                {
                    access.IsActivated = false;
                }
                //// add in updating
                foreach (var access in accessesOfRole.Where(_ => input.AccessControlIds.Contains(_.AccessControlId) && !_.IsActivated))
                {
                    access.IsActivated = true;
                }
                // ADD NEW
                var newAccessesOfRole = input.AccessControlIds.Where(_ => !accessesOfRole.Select(_ => _.AccessControlId).Contains(_));
                await _accessOfRoleRepository.InsertRangeAsync(newAccessesOfRole.Select(a => new AccessOfRole
                {
                    RoleId = role.Id,
                    AccessControlId = a,
                    IsActivated = true
                }).ToList(), false);
                await unitOfWork.SaveChangesAsync();
                unitOfWork.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteRole(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _roleRepository = unitOfWork.Repository<Role>();
            _accessOfRoleRepository = unitOfWork.Repository<AccessOfRole>();
            try
            {
                unitOfWork.BeginTransaction();
                var role = await GetOrThrow(_roleRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Vai trò"));

                // delete acces of role
                var accessOfRole = await _accessOfRoleRepository.GetByRole(role.Id);
                if (accessOfRole.Any())
                    await _accessOfRoleRepository.DeleteRangeAsync(accessOfRole);
                // delete role
                await _roleRepository.DeleteAsync(role);
                unitOfWork.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #endregion

        #region AccessControl

        public async Task<LoadResult> GetAccessControls(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            var source = (await _accessControlRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddAccessControl(BaseSettingModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            if (await _accessControlRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Quyền"));

            await _accessControlRepository.InsertAsync(new AccessControl
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateAccessControl(BaseSettingModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            if (await _accessControlRepository.IsDuplicated(input.Id, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Quyền"));

            var accessControl = await GetOrThrow(_accessControlRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Quyền"));

            accessControl.Name = input.Name.Trim();

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAccessControl(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            var accessControl = await GetOrThrow(_accessControlRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Quyền"));
            await _accessControlRepository.DeleteAsync(accessControl);

            return true;
        }

        #endregion

        #region AccessOfRole

        public async Task<bool> UpdateAccessOfRole(AccessOfRoleModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _roleRepository = unitOfWork.Repository<Role>();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();
            _accessOfRoleRepository = unitOfWork.Repository<AccessOfRole>();


            var role = await GetOrThrow(_roleRepository, input.RoleId, string.Format(AppMessages.ThisObjectNotFound, "Vai trò"));

            var accessControl = await _accessControlRepository.FindAsync(input.AccessControlId) ??
                                throw new AppException(string.Format(AppMessages.ThisObjectNotFound, "Quyền"));

            var accessOfRole = await _accessOfRoleRepository.Get(role.Id, accessControl.Id);
            // add new
            if (accessOfRole == null)
                await _accessOfRoleRepository.InsertAsync(new AccessOfRole
                {
                    RoleId = role.Id,
                    AccessControlId = accessControl.Id,
                    IsActivated = true
                });
            // update
            else accessOfRole.IsActivated = input.IsActivated;

            await unitOfWork.SaveChangesAsync();
            return true;
        }

        #endregion

        #region User

        public async Task<LoadResult> GetUsers(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            try
            {
                _userRepository = unitOfWork.Repository<User>();

                var source = _userRepository.GetUsers();
                return await LoadAsync(source, loadOptions);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> AddUser(UserModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _userRepository = unitOfWork.Repository<User>();
            _userRoleRepository = unitOfWork.Repository<UserRole>();

            try
            {
                if (await _userRepository.IsDuplicated(0, input.Email))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Email"));

                unitOfWork.BeginTransaction();
                //
                // add to user table
                var salt = PasswordHash.GetSalt();
                var user = new User
                {
                    Email = input.Email.Trim(),
                    Name = input.Name.Trim(),
                    Password = PasswordHash.GetHash(string.Concat(input.Password, salt)),
                    Salt = salt,
                    UnitId = input.UnitId,
                };
                await _userRepository.InsertAsync(user);
                //
                // add to userRole table
                await _userRoleRepository.InsertAsync(new UserRole
                {
                    RoleId = input.RoleId,
                    UserId = user.Id,
                    IsActivated = true
                });

                unitOfWork.CommitTransaction();
                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateUser(UserModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _userRepository = unitOfWork.Repository<User>();
            _userRoleRepository = unitOfWork.Repository<UserRole>();

            try
            {
                if (await _userRepository.IsDuplicated(input.Id, input.Email))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Email Người dùng"));

                unitOfWork.BeginTransaction();

                var user = await GetOrThrow(_userRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Người dùng"));
                user.Email = input.Email.Trim();
                user.Name = input.Name.Trim();
                user.UnitId = input.UnitId;
                //
                // UPDATE USER ROLE
                var userRole = await _userRoleRepository.GetActivatedUserRole(user.Id) ??
                               throw new AppException(string.Format(AppMessages.ThisObjectNotFound, "Người dùng"));

                if (userRole.RoleId != input.RoleId)
                {
                    userRole.IsActivated = false;

                    var existedUserRole = await _userRoleRepository.GetUnactivatedUserRole(user.Id, input.RoleId);
                    if (existedUserRole != null)
                        existedUserRole.IsActivated = true;
                    else
                        await unitOfWork.Repository<UserRole>().InsertAsync(new UserRole
                        {
                            RoleId = input.RoleId,
                            UserId = user.Id,
                            IsActivated = true
                        }, false);
                }

                await unitOfWork.SaveChangesAsync();
                unitOfWork.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _userRepository = unitOfWork.Repository<User>();
            _userRoleRepository = unitOfWork.Repository<UserRole>();

            try
            {
                unitOfWork.BeginTransaction();
                var user = await GetOrThrow(_userRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Người dùng"));
                // USER ROLE
                var userRole = await _userRoleRepository.GetUserRoles(user.Id) ??
                    throw new AppException(string.Format(AppMessages.ThisObjectNotFound, "Người dùng"));
                // DELETE USER ROLE
                await _userRoleRepository.DeleteRangeAsync(userRole);
                // DELETE USER
                await _userRepository.DeleteAsync(user);

                unitOfWork.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #endregion

        #region ChangeOfficialDocumentType

        public async Task<LoadResult> GetChangeOfficialDocumentTypes(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocumentType = unitOfWork.Repository<ChangeOfficialDocumentType>();

            var types = (await _changeOfficialDocumentType.GetAllAsync()).ToList();
            return LoadCustom(types, loadOptions);
        }

        public async Task<bool> AddChangeOfficialDocumentType(BaseSettingModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocumentType = unitOfWork.Repository<ChangeOfficialDocumentType>();

            try
            {
                if (await _changeOfficialDocumentType.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại giấy tờ/biểu mẫu"));

                // ADD
                var type = new ChangeOfficialDocumentType { Name = input.Name.Trim() };
                await _changeOfficialDocumentType.InsertAsync(type);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateChangeOfficialDocumentType(BaseSettingModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocumentType = unitOfWork.Repository<ChangeOfficialDocumentType>();

            try
            {
                if (await _changeOfficialDocumentType.IsDuplicated(input.Id, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại giấy tờ/biểu mẫu"));

                // UPDATE
                var type = await GetOrThrow(_changeOfficialDocumentType, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Loại giấy tờ/biểu mẫu"));
                type.Name = input.Name.Trim();
                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteChangeOfficialDocumentType(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocumentType = unitOfWork.Repository<ChangeOfficialDocumentType>();

            try
            {
                var type = await GetOrThrow(_changeOfficialDocumentType, id, string.Format(AppMessages.ThisObjectNotFound, "Loại giấy tờ/biểu mẫu"));
                //
                // DELETE
                await _changeOfficialDocumentType.DeleteAsync(type);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #endregion

        #region ChangeOfficialDocument

        public async Task<LoadResult> GetChangeOfficialDocuments(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocument = unitOfWork.Repository<ChangeOfficialDocument>();

            var source = (await _changeOfficialDocument.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddChangeOfficialDocument(ChangeOfficialDocumentModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocument = unitOfWork.Repository<ChangeOfficialDocument>();
            _changeOfficialDocumentType = unitOfWork.Repository<ChangeOfficialDocumentType>();

            try
            {
                if (await _changeOfficialDocument.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Giấy tờ/biểu mẫu"));

                var type = await GetOrThrow(_changeOfficialDocumentType, input.ChangeOfficialDocumentTypeId,
                    string.Format(AppMessages.ThisObjectNotFound, "Loại giấy tờ/biểu mẫu"));

                // ADD
                var changeOfficialDocument = new ChangeOfficialDocument { Name = input.Name.Trim(), ChangeOfficialDocumentTypeId = type.Id };
                await _changeOfficialDocument.InsertAsync(changeOfficialDocument);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateChangeOfficialDocument(ChangeOfficialDocumentModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocument = unitOfWork.Repository<ChangeOfficialDocument>();
            _changeOfficialDocumentType = unitOfWork.Repository<ChangeOfficialDocumentType>();

            try
            {
                if (await _changeOfficialDocument.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Giấy tờ/biểu mẫu"));

                var type = await GetOrThrow(_changeOfficialDocumentType, input.ChangeOfficialDocumentTypeId,
                    string.Format(AppMessages.ThisObjectNotFound, "Loại giấy tờ/biểu mẫu"));
                //
                // UPDATE
                var changeOfficialDocument = await GetOrThrow(_changeOfficialDocument, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Giấy tờ/biểu mẫu"));
                changeOfficialDocument.Name = input.Name.Trim();
                changeOfficialDocument.ChangeOfficialDocumentTypeId = type.Id;
                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteChangeOfficialDocument(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _changeOfficialDocument = unitOfWork.Repository<ChangeOfficialDocument>();

            try
            {
                var changeOfficialDocument = await GetOrThrow(_changeOfficialDocument, id, string.Format(AppMessages.ThisObjectNotFound, "Giấy tờ/biểu mẫu"));
                //
                // DELETE
                await _changeOfficialDocument.DeleteAsync(changeOfficialDocument);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #endregion
    }
}