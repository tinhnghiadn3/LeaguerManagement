using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClosedXML.Excel;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Extension;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NLog;

namespace LeaguerManagement.Services
{
    public class LeaguerService : BaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private IRepository<Leaguer> _leaguerRepository;
        private IRepository<LeaguerAttachment> _leaguerAttachmentRepository;
        private IRepository<AppliedDocument> _appliedDocumentRepository;
        private IRepository<AppliedDocumentAttachment> _appliedDocumentAttachmentRepository;
        private IRepository<ChangeOfficialDocumentType> _changeOfficialDocumentTypeRepository;
        private IRepository<ChangeOfficialDocument> _changeOfficialDocumentRepository;


        public LeaguerService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper,
            ILogger logger, IOptionsSnapshot<GlobalSettings> settings) : base(unitOfWorkFactory, settings)
        {

            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LoadResult> GetCurrentLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            var source = await _leaguerRepository.GetCurrentLeaguers(unitOfWork.CurrentUser.UnitId);
            return LoadCustom(source, loadOptions);
        }

        public async Task<LoadResult> GetAllLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            var source = await _leaguerRepository.GetAllLeaguers(unitOfWork.CurrentUser.UnitId);
            return LoadCustom(source, loadOptions);
        }
        public async Task<IList<StatusStatisticModel>> GetStatusStatistics()
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            var leaguers = await _leaguerRepository.GetCurrentLeaguers(unitOfWork.CurrentUser.UnitId);

            var officials = leaguers.Where(_ => _.StatusId == AppLeaguerStatus.Official.ToInt()).ToList();
            var preliminary = leaguers.Where(_ => _.StatusId == AppLeaguerStatus.Preliminary.ToInt()).ToList();

            return new List<StatusStatisticModel>
            {
                new() {StatusId = AppLeaguerStatus.Official.ToInt(), StatusName = "Chính thức", Amount = officials.Count},
                new() {StatusId = AppLeaguerStatus.Preliminary.ToInt(), StatusName = "Dự bị", Amount = preliminary.Count},
            };
        }

        public async Task<ReferenceWithAttachmentModel<LeaguerModel>> GetLeaguerDetail(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            return await _leaguerRepository.GetLeaguerDetail(id) ??
                   throw new AppException(string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
        }

        public async Task<bool> CheckExistLeaguer(CheckExistDataModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            return await _leaguerRepository.IsExistingLeaguer(input.LeaguerName, input.CardNumber, input.LeaguerId);
        }

        public async Task<int> AddLeaguer(LeaguerModel input)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _leaguerRepository = unitOfWork.Repository<Leaguer>();

                // check exist with card number
                if (await _leaguerRepository.IsExistingLeaguer(input.Name, input.CardNumber))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Đảng viên"));
                //
                // adding
                var leaguer = _mapper.Map<LeaguerModel, Leaguer>(input);
                leaguer.StatusId = AppLeaguerStatus.Preliminary.ToInt();
                leaguer.IsActivated = true;
                await _leaguerRepository.InsertAsync(leaguer);

                return leaguer.Id;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateLeaguer(LeaguerModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            _leaguerAttachmentRepository = unitOfWork.Repository<LeaguerAttachment>();

            try
            {
                // check exist with card number (except current)
                if (await _leaguerRepository.IsExistingLeaguer(input.Name, input.CardNumber, input.Id))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Đảng viên"));
                //
                // check exist leaguer
                var leaguer = await GetOrThrow(_leaguerRepository, input.Id,
                    string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
                //
                //
                unitOfWork.BeginTransaction();
                //
                // remove current avatar
                if (input.AvatarId == 0)
                {
                    var avatarId = await _leaguerAttachmentRepository.GetCurrentAvatarId(leaguer.Id);
                    if (avatarId != 0) await DeleteLeaguerAttachment(leaguer.Id, avatarId);
                }
                // updating
                _mapper.Map(input, leaguer);
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

        public async Task<bool> DeleteLeaguer(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            _leaguerAttachmentRepository = unitOfWork.Repository<LeaguerAttachment>();

            try
            {
                //
                // check exist leaguer
                var leaguer = await GetOrThrow(_leaguerRepository, id,
                    string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));

                var attachments = await _leaguerAttachmentRepository.GetCurrentAttachments(leaguer.Id);
                //
                //
                unitOfWork.BeginTransaction();
                //
                // remove current attachments
                if (attachments.Any())
                {
                    await _leaguerAttachmentRepository.DeleteRangeAsync(attachments);
                }
                // delete leaguer
                await _leaguerRepository.DeleteAsync(leaguer);
                
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

        public async Task<AttachmentModel> SaveAttachment(int leaguerId, string fileName, IFormFile formFile, bool isAvatar)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            _leaguerAttachmentRepository = unitOfWork.Repository<LeaguerAttachment>();

            try
            {
                if (isAvatar)
                    ValidateImage(fileName, formFile.Length);
                else ValidateFile(fileName, formFile.Length);

                var leaguer = await GetOrThrow(_leaguerRepository, leaguerId,
                    string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
                //
                unitOfWork.BeginTransaction();
                //
                // Remove current avatar
                if (isAvatar)
                {
                    var avatarId = await _leaguerAttachmentRepository.GetCurrentAvatarId(leaguerId);
                    if (avatarId != 0) await DeleteLeaguerAttachment(leaguerId, avatarId);
                }
                //
                // Create task folder if not exist
                var folderPath = isAvatar ? GetOrCreateLeaguerFolder("Avatar", leaguer.Id)
                    : GetOrCreateLeaguerFolder("Information", leaguer.Id);
                //
                // Attachment
                var attachedFile = new LeaguerAttachment
                {
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = unitOfWork.CurrentUser.UserId.Value,
                    FileName = fileName,
                    FilePath = string.Empty,
                    FileUrl = string.Empty,
                    FileExtension = Path.GetExtension(fileName),
                    FileSize = formFile.Length,
                    LeaguerId = leaguer.Id,
                    IsAvatar = isAvatar
                };
                await _leaguerAttachmentRepository.InsertAsync(attachedFile);

                var fullName = $"{attachedFile.Id}_{fileName}";
                attachedFile.FileUrl = FileHelper.UploadFile(folderPath, formFile, fullName, out var filePath);
                attachedFile.FilePath = filePath;
                await unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<AttachmentModel>(attachedFile);
                result.ReferenceId = leaguer.Id;
                result.ReferenceName = isAvatar ? "avatar" : "general";

                unitOfWork.CommitTransaction();

                return result;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<IList<ReferenceWithAttachmentModel<AppliedDocumentModel>>> GetOfficialDocuments(int leaguerId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _appliedDocumentRepository = unitOfWork.Repository<AppliedDocument>();
            _changeOfficialDocumentTypeRepository = unitOfWork.Repository<ChangeOfficialDocumentType>();
            _changeOfficialDocumentRepository = unitOfWork.Repository<ChangeOfficialDocument>();


            var officialDocumentTypes = await _changeOfficialDocumentTypeRepository.GetAllAsync();
            var officialDocuments = await _changeOfficialDocumentRepository.GetAllAsync();
            var result = await _appliedDocumentRepository.GetAppliedOfficialDocuments(leaguerId);
            try
            {
                // if have
                if (result.Any())
                {
                    // if same
                    if (result.Count == officialDocuments.Count()) return result;
                    //
                    // if not same
                    unitOfWork.BeginTransaction();
                    // 
                    // for missing
                    var misses = officialDocuments.Where(_ =>
                        !result.Select(r => r.Reference).Select(x => x.OfficialDocumentId).Contains(_.Id));
                    var newDocuments = new List<AppliedDocument>();
                    if (misses.Any())
                    {
                        newDocuments.AddRange(misses.Select(miss => new AppliedDocument
                        { LeaguerId = leaguerId, Name = miss.Name, OfficialDocumentId = miss.Id }));
                        await _appliedDocumentRepository.InsertRangeAsync(newDocuments);
                    }
                    // for more
                    if (result.Count > officialDocuments.Count())
                    {
                        var moreIds = result.Select(r => r.Reference).Select(r => r.Id)
                            .Where(_ => !officialDocuments.Select(o => o.Id).Contains(_));

                        if (moreIds.Any())
                        {
                            var mores = await _appliedDocumentRepository.GetMores(moreIds);
                            if (mores.Any()) await _appliedDocumentRepository.DeleteRangeAsync(mores);
                        }
                    }
                    //
                    unitOfWork.CommitTransaction();
                    return await _appliedDocumentRepository.GetAppliedOfficialDocuments(leaguerId);
                }
                //
                // if not have
                var appliedDocuments = new List<AppliedDocument>();
                foreach (var type in officialDocumentTypes)
                {
                    var documents = officialDocuments.Where(_ => _.ChangeOfficialDocumentTypeId == type.Id);
                    appliedDocuments.AddRange(documents.Select(document => new AppliedDocument { LeaguerId = leaguerId, Name = document.Name, OfficialDocumentId = document.Id }));
                }

                await _appliedDocumentRepository.InsertRangeAsync(appliedDocuments);
                return await _appliedDocumentRepository.GetAppliedOfficialDocuments(leaguerId);
            }
            catch (Exception e)
            {
                if (result.Any() && result.Count != officialDocuments.Count()) unitOfWork.RollbackTransaction();
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> ChangeToOfficial(int leaguerId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            _appliedDocumentRepository = unitOfWork.Repository<AppliedDocument>();
            _appliedDocumentAttachmentRepository = unitOfWork.Repository<AppliedDocumentAttachment>();

            try
            {
                //
                // check exist leaguer
                var leaguer = await GetOrThrow(_leaguerRepository, leaguerId, string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
                //
                var appliedDocuments = await _appliedDocumentRepository.GetAppliedDocuments(leaguer.Id);
                var attachments = await _appliedDocumentAttachmentRepository.GetAppliedOfficialAttachments(leaguer.Id);
                if (!attachments.Any() || attachments.Count >= appliedDocuments.Count) return false;
                leaguer.StatusId = AppLeaguerStatus.Official.ToInt();
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> ChangeToOut(int leaguerId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            try
            {
                //
                // check exist leaguer
                var leaguer = await GetOrThrow(_leaguerRepository, leaguerId, string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
                leaguer.StatusId = AppLeaguerStatus.GetOut.ToInt();
                leaguer.IsActivated = false;
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> ChangeToDead(int leaguerId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            try
            {
                //
                // check exist leaguer
                var leaguer = await GetOrThrow(_leaguerRepository, leaguerId, string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
                leaguer.StatusId = AppLeaguerStatus.Dead.ToInt();
                leaguer.IsActivated = false;
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<AttachmentModel> RenameAttachment(int attachmentId, string newName, int leaguerId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();
            _leaguerAttachmentRepository = unitOfWork.Repository<LeaguerAttachment>();

            try
            {
                ValidateFile(newName);

                var leaguer = await GetOrThrow(_leaguerRepository, leaguerId,
                    string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
                //
                // Get file
                var oldFile = await GetOrThrow(_leaguerAttachmentRepository, attachmentId, string.Format(AppMessages.FileNotFound));
                //
                // File is deleted?
                if (!File.Exists(oldFile.FilePath))
                    throw new AppException(AppMessages.FileIsDeleted);
                //
                // File is not belong to the construction.
                if (oldFile.LeaguerId != leaguer.Id)
                    throw new AppException(AppMessages.FileNotBelongToLeaguer);
                //
                // Get new path
                var pathLength = oldFile.FilePath.Length;
                var oldFileNameLength = oldFile.FileName.Length;
                var newFileName = newName.RemoveVietnameseSigns();
                var newPath = oldFile.FilePath.Substring(0, pathLength - oldFileNameLength) + newFileName;
                //
                // Rename in Folder
                File.Move(oldFile.FilePath, newPath);
                //
                // Rename and Change path in DB
                oldFile.FileName = newFileName;
                oldFile.FilePath = newPath;
                await unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<AttachmentModel>(oldFile);
                result.ReferenceId = oldFile.LeaguerId;
                result.ReferenceName = "general";

                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteAttachmentAsync(int leaguerId, int attachmentId)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _leaguerRepository = unitOfWork.Repository<Leaguer>();
                _leaguerAttachmentRepository = unitOfWork.Repository<LeaguerAttachment>();

                await DeleteLeaguerAttachment(leaguerId, attachmentId);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #region Export Excel

        public async Task<byte[]> ExportExcelAllLeager()
        {
            using var unitOfWork = UnitOfWorkFactory();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            try
            {
                //
                var data = await _leaguerRepository.ExportAllLeaguerToExcel(unitOfWork.CurrentUser.UnitId);
                // export to excel
                return GenerateLeaguerExcel(data);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        #endregion

        #region Applied Attachment

        public async Task<AttachmentModel> SaveAppliedAttachment(int appliedId, string fileName, IFormFile formFile)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _appliedDocumentRepository = unitOfWork.Repository<AppliedDocument>();
            _appliedDocumentAttachmentRepository = unitOfWork.Repository<AppliedDocumentAttachment>();

            try
            {
                ValidateFile(fileName, formFile.Length);

                var applied = await GetOrThrow(_appliedDocumentRepository, appliedId,
                    string.Format(AppMessages.ThisObjectNotFound, "Giấy tờ/biểu mẫu"));
                //
                // Create task folder if not exist
                var folderPath = GetOrCreateLeaguerFolder("Official", applied.LeaguerId);
                //
                // Attachment
                var attachedFile = new AppliedDocumentAttachment
                {
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = unitOfWork.CurrentUser.UserId.Value,
                    FileName = fileName,
                    FilePath = string.Empty,
                    FileUrl = string.Empty,
                    FileExtension = Path.GetExtension(fileName),
                    FileSize = formFile.Length,
                    AppliedDocumentId = applied.Id,
                };
                await _appliedDocumentAttachmentRepository.InsertAsync(attachedFile);

                var fullName = $"{attachedFile.Id}_{fileName}";
                attachedFile.FileUrl = FileHelper.UploadFile(folderPath, formFile, fullName, out var filePath);
                attachedFile.FilePath = filePath;
                await unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<AttachmentModel>(attachedFile);
                result.ReferenceId = applied.Id;
                result.ReferenceName = "official";

                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<AttachmentModel> RenameOfficialAttachment(int attachmentId, string newName, int appliedId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _appliedDocumentRepository = unitOfWork.Repository<AppliedDocument>();
            _appliedDocumentAttachmentRepository = unitOfWork.Repository<AppliedDocumentAttachment>();

            try
            {
                ValidateFile(newName);

                var applied = await GetOrThrow(_appliedDocumentRepository, appliedId,
                    string.Format(AppMessages.ThisObjectNotFound, "Giấy tờ/biểu mẫu"));
                //
                // Get file
                var oldFile = await GetOrThrow(_appliedDocumentAttachmentRepository, attachmentId, string.Format(AppMessages.FileNotFound));
                //
                // File is deleted?
                if (!File.Exists(oldFile.FilePath))
                    throw new AppException(AppMessages.FileIsDeleted);
                //
                // File is not belong to the construction.
                if (oldFile.AppliedDocumentId != applied.Id)
                    throw new AppException(AppMessages.FileNotBelongToLeaguer);
                //
                // Get new path
                var pathLength = oldFile.FilePath.Length;
                var oldFileNameLength = oldFile.FileName.Length;
                var newFileName = newName.RemoveVietnameseSigns();
                var newPath = oldFile.FilePath.Substring(0, pathLength - oldFileNameLength) + newFileName;
                //
                // Rename in Folder
                File.Move(oldFile.FilePath, newPath);
                //
                // Rename and Change path in DB
                oldFile.FileName = newFileName;
                oldFile.FilePath = newPath;
                await unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<AttachmentModel>(oldFile);
                result.ReferenceId = oldFile.AppliedDocumentId;
                result.ReferenceName = "official";

                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteOfficialAttachmentAsync(int appliedId, int attachmentId)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _appliedDocumentRepository = unitOfWork.Repository<AppliedDocument>();
                _appliedDocumentAttachmentRepository = unitOfWork.Repository<AppliedDocumentAttachment>();

                await GetOrThrow(_appliedDocumentRepository, appliedId, string.Format(AppMessages.ThisObjectNotFound, "Giấy tờ/biểu mẫu"));
                var attachment = await GetOrThrow(_appliedDocumentAttachmentRepository, attachmentId, string.Format(AppMessages.FileNotFound));
                // Delete from DB
                await _appliedDocumentAttachmentRepository.DeleteAsync(attachment);
                // Delete from folder
                FileHelper.DeleteFile(attachment.FilePath);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }


        #endregion

        #region Private Method
        private async Task DeleteLeaguerAttachment(int leaguerId, int attachmentId)
        {
            await GetOrThrow(_leaguerRepository, leaguerId, string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));
            var attachment = await GetOrThrow(_leaguerAttachmentRepository, attachmentId, string.Format(AppMessages.FileNotFound));
            // Delete from DB
            await _leaguerAttachmentRepository.DeleteAsync(attachment);
            // Delete from folder
            FileHelper.DeleteFile(attachment.FilePath);
        }

        private byte[] GenerateLeaguerExcel(IList<LeaguerBookModel> excelData)
        {
            //dir path của file template
            using var workbook = new XLWorkbook(Path.GetFullPath(Directory.GetCurrentDirectory() + "\\Contents\\Templates\\Dang Bo So TNMT DS DANG VIEN.xlsx"));
            var worksheet = workbook.GetWorkSheet("Sheet1");
            // declare default variable
            const int totalColumns = 29;
            var currentRow = 4;
            //
            // Start generate content
            var index = 1;
            foreach (var data in excelData)
            {
                currentRow++;
                worksheet.PrintCellsValue(data.Unit, currentRow, totalColumns);
                foreach (var leaguer in data.Leaguers)
                {
                    currentRow++;
                    worksheet.PrintCellsValue(leaguer, currentRow, totalColumns, index, 3);
                    index++;
                }
            }

            worksheet.Columns().Style.Alignment.WrapText = true;
            //add to stream return to controller
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        #endregion
    }
}
