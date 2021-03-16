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
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels.Settings;
using LeaguerManagement.Entities.ViewModels.Shared;
using LeaguerManagement.Repositories;
using Microsoft.Extensions.Options;
using NLog;
using City = LeaguerManagement.Entities.Entities.City;

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

        private IRepository<District> _districtRepository;
        private IRepository<Ward> _wardRepository;
        private IRepository<Apartment> _apartmentRepository;
        private IRepository<Notification> _notificationRepository;
        private IRepository<Street> _streetRepository;

        //private IRepository<Applicant> _applicantRepository;
        //private IRepository<Certificate> _certificateRepository;

        private IRepository<DocumentType> _documentTypeRepository;
        private IRepository<CopyType> _copyTypeRepository;
        private IRepository<CertificateType> _certificateTypeRepository;
        private IRepository<Holiday> _holidayRepository;

        public SettingService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper,
            ILogger logger, IOptionsSnapshot<GlobalSettings> settings) : base(unitOfWorkFactory, settings)
        {

            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LookupModel> GetLookup(string keys)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            var keyArray = keys?.Split(',');
            var result = new LookupModel();

            if (string.IsNullOrEmpty(keys))
            {
                return new LookupModel
                {
                    Roles = (await unitOfWork.Repository<Role>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Districts = (await unitOfWork.Repository<District>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Wards = _mapper.Map<IList<WardModel>>(await unitOfWork.Repository<Ward>().GetAllAsync()),
                    //
                    ApplicantTypes = (await unitOfWork.Repository<ApplicantType>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    DocumentTypes = (await unitOfWork.Repository<DocumentType>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    FileTypes = (await unitOfWork.Repository<FileType>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Symbol }).ToList(),
                    //
                    Notifications = (await unitOfWork.Repository<Notification>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Statuses = (await unitOfWork.Repository<Status>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Cities = (await unitOfWork.Repository<City>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Streets = (await unitOfWork.Repository<Street>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Formalities = (await unitOfWork.Repository<Formality>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Apartments = _mapper.Map<IList<ApartmentModel>>(await unitOfWork.Repository<Apartment>().GetAllAsync()),
                    //
                    IdentifyNumberTypes = (await unitOfWork.Repository<IdentifyNumberType>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    CopyTypes = (await unitOfWork.Repository<CopyType>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    Pronouns = (await unitOfWork.Repository<Pronouns>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    //
                    ConfirmPurposes = (await unitOfWork.Repository<ConfirmPurpose>().GetAllAsync()).Select(_ =>
                        new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList(),
                    PointTypes = (await unitOfWork.Repository<PointType>().GetAllAsync()).Select(_ =>
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
                keyArray.Any(_ => _ == AppDropdownDataType.Districts.ToString()))
            {
                result.Districts = (await unitOfWork.Repository<District>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Wards.ToString()))
            {
                result.Wards = _mapper.Map<IList<WardModel>>(await unitOfWork.Repository<Ward>().GetAllAsync());
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.ApplicantTypes.ToString()))
            {
                result.ApplicantTypes = (await unitOfWork.Repository<ApplicantType>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.DocumentTypes.ToString()))
            {
                result.DocumentTypes = (await unitOfWork.Repository<DocumentType>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.FileTypes.ToString()))
            {
                result.FileTypes = (await unitOfWork.Repository<FileType>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Notifications.ToString()))
            {
                result.Notifications = (await unitOfWork.Repository<Notification>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Statuses.ToString()))
            {
                result.Statuses = (await unitOfWork.Repository<Status>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Cities.ToString()))
            {
                result.Cities = (await unitOfWork.Repository<City>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Streets.ToString()))
            {
                result.Streets = (await unitOfWork.Repository<Street>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Formalities.ToString()))
            {
                result.Formalities = (await unitOfWork.Repository<Formality>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Apartments.ToString()))
            {
                result.Apartments = _mapper.Map<IList<ApartmentModel>>(await unitOfWork.Repository<Apartment>().GetAllAsync());
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.IdentifyNumberTypes.ToString()))
            {
                result.IdentifyNumberTypes = (await unitOfWork.Repository<IdentifyNumberType>().GetAllAsync()).Select(
                    _ => new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.CopyTypes.ToString()))
            {
                result.CopyTypes = (await unitOfWork.Repository<CopyType>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.Pronouns.ToString()))
            {
                result.Pronouns = (await unitOfWork.Repository<Pronouns>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> {Key = _.Id, Value = _.Name}).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.ConfirmPurposes.ToString()))
            {
                result.ConfirmPurposes = (await unitOfWork.Repository<ConfirmPurpose>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            if (string.IsNullOrEmpty(keys) ||
                keyArray.Any(_ => _ == AppDropdownDataType.PointTypes.ToString()))
            {
                result.PointTypes = (await unitOfWork.Repository<PointType>().GetAllAsync()).Select(_ =>
                    new DropDownModel<int> { Key = _.Id, Value = _.Name }).ToList();
            }

            return result;
        }

        #region Role

        public async Task<LoadResult> GetRoles(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _roleRepository = unitOfWork.Repository<Role>();

            var owners = await _roleRepository.GetRoles();
            return LoadCustom(owners, loadOptions);
        }

        public async Task<bool> AddRole(RoleModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            var source = (await _accessControlRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddAccessControl(AccessControlModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            if (await _accessControlRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Quyền"));

            await _accessControlRepository.InsertAsync(new AccessControl
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateAccessControl(AccessControlModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _accessControlRepository = unitOfWork.Repository<AccessControl>();

            var accessControl = await GetOrThrow(_accessControlRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Quyền"));
            await _accessControlRepository.DeleteAsync(accessControl);

            return true;
        }

        #endregion

        #region AccessOfRole

        public async Task<bool> UpdateAccessOfRole(AccessOfRoleModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
                    JobPosition = input.JobPosition
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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
            using var unitOfWork = UnitOfWorkFactory.Invoke();
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

        #region District

        public async Task<LoadResult> GetDistricts(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _districtRepository = unitOfWork.Repository<District>();

            var source = (await _districtRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddDistrict(DistrictModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _districtRepository = unitOfWork.Repository<District>();

            if (await _districtRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Quận/Huyện"));

            await _districtRepository.InsertAsync(new District
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateDistrict(DistrictModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _districtRepository = unitOfWork.Repository<District>();

            if (await _districtRepository.IsDuplicated(input.Id, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Quận/Huyện"));

            var district = await GetOrThrow(_districtRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Quận/Huyện"));
            district.Name = input.Name.Trim();

            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDistrict(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _districtRepository = unitOfWork.Repository<District>();

            var district = await GetOrThrow(_districtRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Quận/Huyện"));
            await _districtRepository.DeleteAsync(district);

            return true;
        }

        #endregion

        #region Ward

        public async Task<LoadResult> GetWards(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _wardRepository = unitOfWork.Repository<Ward>();

            var wardsQuery = _wardRepository.GetWardsQuery();
            return await LoadAsync(wardsQuery, loadOptions);
        }

        public async Task<LoadResult> GetWardsByDistrict(DataSourceLoadOptionsBase loadOptions, int districtId)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _wardRepository = unitOfWork.Repository<Ward>();

            var wardsQuery = _wardRepository.GetWardsByDistrictQuery(districtId);
            return await LoadAsync(wardsQuery, loadOptions);
        }

        public async Task<bool> AddWard(WardModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _wardRepository = unitOfWork.Repository<Ward>();
            _districtRepository = unitOfWork.Repository<District>();

            try
            {
                if (await _wardRepository.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Phường/Xã"));

                var district = await GetOrThrow(_districtRepository, input.DistrictId.Value, string.Format(AppMessages.ThisObjectNotFound, "Quận/Huyện"));

                await _wardRepository.InsertAsync(new Ward
                {
                    Name = input.Name.Trim(),
                    DistrictId = district.Id
                });

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateWard(WardModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _wardRepository = unitOfWork.Repository<Ward>();
            _districtRepository = unitOfWork.Repository<District>();
            try
            {
                if (await _wardRepository.IsDuplicated(input.Id, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Phường/Xã"));

                var district = await GetOrThrow(_districtRepository, input.DistrictId.Value, string.Format(AppMessages.ThisObjectNotFound, "Quận/Huyện"));
                var ward = await GetOrThrow(_wardRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Phường/Xã"));

                ward.Name = input.Name.Trim();
                ward.DistrictId = district.Id;

                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteWard(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _wardRepository = unitOfWork.Repository<Ward>();
            try
            {
                var ward = await GetOrThrow(_wardRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Phường/Xã"));

                await _wardRepository.DeleteAsync(ward);

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

        #region Street

        public async Task<LoadResult> GetStreets(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _streetRepository = unitOfWork.Repository<Street>();

            var source = (await _streetRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddStreet(StreetModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _streetRepository = unitOfWork.Repository<Street>();

            if (await _streetRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Đường"));

            await _streetRepository.InsertAsync(new Street
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateStreet(StreetModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _streetRepository = unitOfWork.Repository<Street>();

            if (await _streetRepository.IsDuplicated(input.Id, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Đường"));

            var street = await GetOrThrow(_streetRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Đường"));
            street.Name = input.Name.Trim();

            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStreet(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _streetRepository = unitOfWork.Repository<Street>();

            var street = await GetOrThrow(_streetRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Đường"));
            await _streetRepository.DeleteAsync(street);

            return true;
        }

        #endregion

        #region Apartment

        public async Task<LoadResult> GetApartments(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _apartmentRepository = unitOfWork.Repository<Apartment>();

            var apartmentsQuery = (await _apartmentRepository.GetAllAsync()).ToList();
            return LoadCustom(apartmentsQuery, loadOptions);
        }

        public async Task<bool> AddApartment(ApartmentModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _apartmentRepository = unitOfWork.Repository<Apartment>();
            _wardRepository = unitOfWork.Repository<Ward>();
            try
            {
                if (await _apartmentRepository.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Căn hộ"));

                var ward = await GetOrThrow(_wardRepository, input.WardId.Value, string.Format(AppMessages.ThisObjectNotFound, "Phường/Xã"));

                await _apartmentRepository.InsertAsync(new Apartment
                {
                    Name = input.Name.Trim(),
                    WardId = ward.Id
                });

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateApartment(ApartmentModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _apartmentRepository = unitOfWork.Repository<Apartment>();
            _wardRepository = unitOfWork.Repository<Ward>();
            try
            {
                if (await _apartmentRepository.IsDuplicated(input.Id, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Căn hộ"));

                var apartment = await GetOrThrow(_apartmentRepository, input.WardId.Value, string.Format(AppMessages.ThisObjectNotFound, "Căn hộ"));
                var ward = await GetOrThrow(_wardRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Phường/Xã"));

                apartment.Name = input.Name.Trim();
                apartment.WardId = ward.Id;

                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteApartment(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _apartmentRepository = unitOfWork.Repository<Apartment>();
            try
            {
                var apartment = await GetOrThrow(_apartmentRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Căn hộ"));
                await _apartmentRepository.DeleteAsync(apartment);
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

        #region Notification

        public async Task<LoadResult> GetNotifications(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _notificationRepository = unitOfWork.Repository<Notification>();

            var ownersQuery = (await _notificationRepository.GetAllAsync()).ToList();
            return LoadCustom(ownersQuery, loadOptions);
        }

        public async Task<bool> AddNotification(NotificationModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _notificationRepository = unitOfWork.Repository<Notification>();
            try
            {
                if (await _notificationRepository.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Thông báo"));


                await _notificationRepository.InsertAsync(new Notification
                {
                    Name = input.Name.Trim(),
                    Description = input.Description
                });

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateNotification(NotificationModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _notificationRepository = unitOfWork.Repository<Notification>();
            try
            {
                if (await _notificationRepository.IsDuplicated(input.Id, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Thông báo"));

                var notification = await GetOrThrow(_notificationRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Thông báo"));

                notification.Name = input.Name.Trim();
                notification.Description = input.Description;

                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteNotification(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _notificationRepository = unitOfWork.Repository<Notification>();
            try
            {
                var notification = await GetOrThrow(_notificationRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Thông báo"));
                await _notificationRepository.DeleteAsync(notification);
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

        #region DocumentType

        public async Task<LoadResult> GetDocumentTypes(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _documentTypeRepository = unitOfWork.Repository<DocumentType>();

            var source = (await _documentTypeRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddDocumentType(DocumentTypeModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _documentTypeRepository = unitOfWork.Repository<DocumentType>();

            if (await _documentTypeRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại văn bản"));

            await _documentTypeRepository.InsertAsync(new DocumentType
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateDocumentType(DocumentTypeModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _documentTypeRepository = unitOfWork.Repository<DocumentType>();

            if (await _documentTypeRepository.IsDuplicated(input.Id, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại văn bản"));

            var documentType = await GetOrThrow(_documentTypeRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Loại văn bản"));
            documentType.Name = input.Name.Trim();
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _documentTypeRepository = unitOfWork.Repository<DocumentType>();

            var documentType = await GetOrThrow(_documentTypeRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Loại văn bản"));
            await _documentTypeRepository.DeleteAsync(documentType);

            return true;
        }

        #endregion

        #region CopyType

        public async Task<LoadResult> GetCopyTypes(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _copyTypeRepository = unitOfWork.Repository<CopyType>();

            var source = (await _copyTypeRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddCopyType(CopyTypeModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _copyTypeRepository = unitOfWork.Repository<CopyType>();

            if (await _copyTypeRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại sao lưu"));

            await _copyTypeRepository.InsertAsync(new CopyType
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateCopyType(CopyTypeModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _copyTypeRepository = unitOfWork.Repository<CopyType>();

            if (await _copyTypeRepository.IsDuplicated(input.Id, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại sao lưu"));

            var copyType = await GetOrThrow(_copyTypeRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Loại sao lưu"));
            copyType.Name = input.Name.Trim();
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCopyType(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _copyTypeRepository = unitOfWork.Repository<CopyType>();

            var copyType = await GetOrThrow(_copyTypeRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Loại sao lưu"));
            await _copyTypeRepository.DeleteAsync(copyType);

            return true;
        }

        #endregion

        #region CertificateType

        public async Task<LoadResult> GetCertificateTypes(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _certificateTypeRepository = unitOfWork.Repository<CertificateType>();

            var source = (await _certificateTypeRepository.GetAllAsync()).ToList();
            return LoadCustom(source, loadOptions);
        }

        public async Task<bool> AddCertificateType(CertificateTypeModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _certificateTypeRepository = unitOfWork.Repository<CertificateType>();

            if (await _certificateTypeRepository.IsDuplicated(0, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại GCN"));

            await _certificateTypeRepository.InsertAsync(new CertificateType
            {
                Name = input.Name.Trim()
            });

            return true;
        }

        public async Task<bool> UpdateCertificateType(CertificateTypeModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _certificateTypeRepository = unitOfWork.Repository<CertificateType>();

            if (await _certificateTypeRepository.IsDuplicated(input.Id, input.Name))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Loại sao lưu"));

            var certificateType = await GetOrThrow(_certificateTypeRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Loại GCN"));
            certificateType.Name = input.Name.Trim();
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCertificateType(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _certificateTypeRepository = unitOfWork.Repository<CertificateType>();

            var certificateType = await GetOrThrow(_certificateTypeRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Loại GCN"));
            await _certificateTypeRepository.DeleteAsync(certificateType);

            return true;
        }

        #endregion

        #region Holiday

        public async Task<LoadResult> GetHolidays(DataSourceLoadOptionsBase loadOptions, int year)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            var source = await _holidayRepository.GetHolidays(year);
            return LoadCustom(source, loadOptions);
        }

        public async Task<IList<HolidayModel>> GetHolidaySettings(int year)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            var settings = _mapper.Map<IList<Holiday>, IList<HolidayModel>>(await _holidayRepository.GetListHolidaySettings(year));
            foreach (var setting in settings)
            {
                setting.Year = setting.Date.Year;
            }

            return settings;
        }

        public async Task<bool> AddHolidaySettings(HolidayModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            var currentSettings = await _holidayRepository.GetHolidaySettings(input.Year);
            if (currentSettings != null)
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, $"Cài đặt năm {input.Year}"));

            try
            {
                //unitOfWork.BeginTransaction();

                var settings = _mapper.Map<HolidayModel, Holiday>(input);
                settings.Name = $"Năm {input.Year}";
                settings.Date = new DateTime(input.Year, 1, 1);

                await _holidayRepository.InsertAsync(settings);

                //await UpdateHolidays(new List<Holiday>(), input, _holidayRepository);

                //unitOfWork.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                //unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateHolidaySettings(HolidayModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            try
            {
                var holidaySettings = await _holidayRepository.GetHolidaySettings(input.Year) ??
                                      throw new AppException(string.Format(AppMessages.ThisObjectNotFound,
                                          "Cài đặt ngày nghỉ"));

                var holidays = await _holidayRepository.GetHolidays(input.Year);

                unitOfWork.BeginTransaction();

                //update settings
                _mapper.Map(input, holidaySettings);
                // save changes
                await unitOfWork.SaveChangesAsync();
                // 
                await UpdateHolidays(holidays, input, _holidayRepository);

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

        public async Task<bool> AddHoliday(HolidayModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            if (await _holidayRepository.IsDuplicated(0, input.Name, input.Date))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Ngày nghỉ"));

            await _holidayRepository.InsertAsync(new Holiday
            {
                Name = input.Name.Trim(),
                Date = input.Date
            });

            return true;
        }

        public async Task<bool> UpdateHoliday(HolidayModel input)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            if (await _holidayRepository.IsDuplicated(input.Id, input.Name, input.Date))
                throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Ngày nghỉ"));

            var holiday = await GetOrThrow(_holidayRepository, input.Id, string.Format(AppMessages.ThisObjectNotFound, "Ngày nghỉ"));
            holiday.Name = input.Name.Trim();
            holiday.Date = input.Date;
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteHoliday(int id)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _holidayRepository = unitOfWork.Repository<Holiday>();

            var holiday = await GetOrThrow(_holidayRepository, id, string.Format(AppMessages.ThisObjectNotFound, "Ngày nghỉ"));
            await _holidayRepository.DeleteAsync(holiday);

            return true;
        }

        #endregion

        #region Private Method

        private async Task UpdateHolidays(IList<Holiday> holidays, HolidayModel input, IRepository<Holiday> holidayRepository)
        {
            var saturdays = holidays.Where(_ => _.IsSaturday != null && _.IsSaturday.Value && _.Date.Year == input.Year).ToList();
            if (input.IsSaturday)
            {
                if (!saturdays.Any())
                {
                    var saturdaysInYear = DateTimeHelper.GenerateSaturday(input.Year);
                    var newSaturdays = new List<Holiday>();
                    for (var i = 1; i <= saturdaysInYear.Count; i++)
                    {
                        newSaturdays.Add(new Holiday
                        {
                            Name = $"Ngày thứ bảy thứ {i}",
                            Date = saturdaysInYear[i - 1],
                            IsSaturday = true,
                            IsSettings = false
                        });
                    }
                    await holidayRepository.InsertRangeAsync(newSaturdays.OrderBy(_ => _.Date));
                }
            }
            else
            {
                if (saturdays.Any())
                    await holidayRepository.DeleteRangeAsync(saturdays);
            }
            // sunday
            var sundays = holidays.Where(_ => _.IsSunday != null && _.IsSunday.Value && _.Date.Year == input.Year).ToList();
            if (input.IsSunday)
            {
                if (!sundays.Any())
                {
                    var sundaysInYear = DateTimeHelper.GenerateSunday(input.Year);
                    var newSundays = new List<Holiday>();
                    for (var i = 1; i <= sundaysInYear.Count; i++)
                    {
                        newSundays.Add(new Holiday
                        {
                            Name = $"Ngày chủ nhật thứ {i}",
                            Date = sundaysInYear[i - 1],
                            IsSunday = true,
                            IsSettings = false
                        });
                    }
                    await holidayRepository.InsertRangeAsync(newSundays.OrderBy(_ => _.Date));
                }
            }
            else
            {
                if (sundays.Any())
                    await holidayRepository.DeleteRangeAsync(sundays);
            }
            // 01/01
            var date11 = holidays.FirstOrDefault(_ => _.Is11 != null && _.Is11.Value && _.Date.Year == input.Year);
            if (input.Is11)
            {
                if (date11 == null)
                {
                    var newDate11 = new Holiday
                    {
                        Name = "Tết dương lịch",
                        Date = new DateTime(input.Year, 1, 1),
                        Is11 = true,
                        IsSettings = false
                    };
                    await holidayRepository.InsertAsync(newDate11);
                }
            }
            else
            {
                if (date11 != null)
                    await holidayRepository.DeleteAsync(date11);
            }
            // 30/04
            var date304 = holidays.FirstOrDefault(_ => _.Is304 != null && _.Is304.Value && _.Date.Year == input.Year);
            if (input.Is304)
            {
                if (date304 == null)
                {
                    var newDate304 = new Holiday
                    {
                        Name = "Ngày giải phóng miền Nam, thống nhất đất nước",
                        Date = new DateTime(input.Year, 4, 30),
                        Is304 = true,
                        IsSettings = false
                    };
                    await holidayRepository.InsertAsync(newDate304);
                }
            }
            else
            {
                if (date304 != null)
                    await holidayRepository.DeleteAsync(date304);
            }
            // 01/05
            var date15 = holidays.FirstOrDefault(_ => _.Is15 != null && _.Is15.Value && _.Date.Year == input.Year);
            if (input.Is15)
            {
                if (date15 == null)
                {
                    var newDate15 = new Holiday
                    {
                        Name = "Ngày quốc tế lao động",
                        Date = new DateTime(input.Year, 5, 1),
                        Is15 = true,
                        IsSettings = false
                    };
                    await holidayRepository.InsertAsync(newDate15);
                }
            }
            else
            {
                if (date15 != null)
                    await holidayRepository.DeleteAsync(date15);
            }
            // 02/09
            var date29 = holidays.FirstOrDefault(_ => _.Is29 != null && _.Is29.Value && _.Date.Year == input.Year);
            if (input.Is29)
            {
                if (date29 != null) return;

                var newDate29 = new Holiday
                {
                    Name = "Ngày Quốc khánh",
                    Date = new DateTime(input.Year, 9, 2),
                    Is29 = true,
                    IsSettings = false
                };
                await holidayRepository.InsertAsync(newDate29);
            }
            else
            {
                if (date29 != null)
                    await holidayRepository.DeleteAsync(date29);
            }
        }

        #endregion
    }
}