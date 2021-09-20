using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Extension;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Entities.ViewModels.Shared;
using LeaguerManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NLog;

namespace LeaguerManagement.Services
{
    public class DocumentationService : BaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private IRepository<Documentation> _documentationRepository;
        private IRepository<DocumentationAttachment> _documentationAttachmentRepository;

        public DocumentationService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper,
            ILogger logger, IOptionsSnapshot<GlobalSettings> settings) : base(unitOfWorkFactory, settings)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<ReferenceWithAttachmentModel<BaseSettingModel>>> GetDocumentations()
        {
            using var unitOfWork = UnitOfWorkFactory();
            _documentationRepository = unitOfWork.Repository<Documentation>();

            return await _documentationRepository.GetDocumentations();
        }

        public async Task<int> AddDocumentation(BaseSettingModel input)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _documentationRepository = unitOfWork.Repository<Documentation>();

                // check exist with card number
                if (await _documentationRepository.IsDuplicated(0, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Tài liệu"));
                //
                // adding
                var documentation = _mapper.Map<BaseSettingModel, Documentation>(input);
                await _documentationRepository.InsertAsync(documentation);

                return documentation.Id;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateDocumentation(BaseSettingModel input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _documentationRepository = unitOfWork.Repository<Documentation>();
            _documentationAttachmentRepository = unitOfWork.Repository<DocumentationAttachment>();

            try
            {
                // check exist with card number (except current)
                if (await _documentationRepository.IsDuplicated(input.Id, input.Name))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Tài liệu"));
                //
                // check exist documentation
                var documentation = await GetOrThrow(_documentationRepository, input.Id,
                    string.Format(AppMessages.ThisObjectNotFound, "Tài liệu"));
                //
                // updating
                _mapper.Map(input, documentation);
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

        public async Task<bool> DeleteDocumentation(int id)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _documentationRepository = unitOfWork.Repository<Documentation>();
            _documentationAttachmentRepository = unitOfWork.Repository<DocumentationAttachment>();

            try
            {
                //
                // check exist leaguer
                var leaguer = await GetOrThrow(_documentationRepository, id,
                    string.Format(AppMessages.ThisObjectNotFound, "Tài lịệu"));

                var attachments = await _documentationAttachmentRepository.GetCurrentAttachments(leaguer.Id);
                //
                //
                unitOfWork.BeginTransaction();
                //
                // remove current attachments
                if (attachments.Any())
                    await _documentationAttachmentRepository.DeleteRangeAsync(attachments);
                // delete leaguer
                await _documentationRepository.DeleteAsync(leaguer);

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

        public async Task<AttachmentModel> SaveAttachment(int documentationId, string fileName, IFormFile formFile)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _documentationRepository = unitOfWork.Repository<Documentation>();
            _documentationAttachmentRepository = unitOfWork.Repository<DocumentationAttachment>();

            try
            {
                ValidateFile(fileName, formFile.Length);

                var documentation = await GetOrThrow(_documentationRepository, documentationId,
                    string.Format(AppMessages.ThisObjectNotFound, "Tài liệu"));
                //
                unitOfWork.BeginTransaction();
                //
                // Create task folder if not exist
                var folderPath = GetOrCreateDocumentationFolder("Documentations", documentation.Id);
                //
                // Attachment
                var attachedFile = new DocumentationAttachment
                {
                    CreatedDate = DateTime.Now,
                    CreatedByUserId = unitOfWork.CurrentUser.UserId.Value,
                    FileName = fileName,
                    FilePath = string.Empty,
                    FileUrl = string.Empty,
                    FileExtension = Path.GetExtension(fileName),
                    FileSize = formFile.Length,
                    DocumentationId = documentation.Id,
                };
                await _documentationAttachmentRepository.InsertAsync(attachedFile);

                var fullName = $"{attachedFile.Id}_{fileName}";
                attachedFile.FileUrl = FileHelper.UploadFile(folderPath, formFile, fullName, out var filePath);
                attachedFile.FilePath = filePath;
                await unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<AttachmentModel>(attachedFile);
                result.ReferenceId = documentation.Id;
                result.ReferenceName = "documentation";

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


        public async Task<AttachmentModel> RenameAttachment(int attachmentId, string newName, int documentationId)
        {
            using var unitOfWork = UnitOfWorkFactory();
            _documentationRepository = unitOfWork.Repository<Documentation>();
            _documentationAttachmentRepository = unitOfWork.Repository<DocumentationAttachment>();

            try
            {
                ValidateFile(newName);

                var documentation = await GetOrThrow(_documentationRepository, documentationId,
                    string.Format(AppMessages.ThisObjectNotFound, "Tài liệu"));
                //
                // Get file
                var oldFile = await GetOrThrow(_documentationAttachmentRepository, attachmentId, string.Format(AppMessages.FileNotFound));
                //
                // File is deleted?
                if (!File.Exists(oldFile.FilePath))
                    throw new AppException(AppMessages.FileIsDeleted);
                //
                // File is not belong to the construction.
                if (oldFile.DocumentationId != documentation.Id)
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
                result.ReferenceId = oldFile.DocumentationId;
                result.ReferenceName = "documentation";

                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> DeleteAttachmentAsync(int appliedId, int attachmentId)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _documentationRepository = unitOfWork.Repository<Documentation>();
                _documentationAttachmentRepository = unitOfWork.Repository<DocumentationAttachment>();

                await GetOrThrow(_documentationRepository, appliedId, string.Format(AppMessages.ThisObjectNotFound, "Tài liệu"));
                var attachment = await GetOrThrow(_documentationAttachmentRepository, attachmentId, string.Format(AppMessages.FileNotFound));
                // Delete from DB
                await _documentationAttachmentRepository.DeleteAsync(attachment);
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


    }
}
