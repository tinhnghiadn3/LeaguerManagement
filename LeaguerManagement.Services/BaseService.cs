﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Extension;
using LeaguerManagement.Entities.Utilities.Extentsion;
using Microsoft.Extensions.Options;

namespace LeaguerManagement.Services
{
    public class BaseService : IDisposable
    {
        protected readonly Func<IUnitOfWork> UnitOfWorkFactory;
        protected static GlobalSettings Settings;

        private static readonly string[] AllowedImageTypes = { ".jpg", ".jpeg", ".png", ".gif" };
        private static readonly string[] AllowedFileTypes = { ".jpg", ".jpeg", ".png", ".gif", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".rtf", ".txt" };


        public BaseService(Func<IUnitOfWork> unitOfWorkFactory, IOptionsSnapshot<GlobalSettings> settings)
        {
            Settings = settings.Value;
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public static void ValidateImage(string fullFileName, long? fileSize = null)
        {
            if (fullFileName.IsBlank())
                throw new AppException(AppMessages.FileNameNotFound);

            var lastDotPosition = fullFileName.LastIndexOf(".", StringComparison.Ordinal);

            var fileName = fullFileName.Substring(0, lastDotPosition);
            if (fileName.Length > Settings.MaxFileNameLength)
                throw new AppException(string.Format(AppMessages.FileNameTooLong, Settings.MaxFileNameLength));

            var fileType = Path.GetExtension(fullFileName);
            if (fileType.IsBlank() || !AllowedImageTypes.Contains(fileType.ToLower()))
                throw new AppException(AppMessages.FileTypeNotSupported);

            if (fileSize.GetValueOrDefault() > Settings.MaxFileSize)
                throw new AppException(string.Format(AppMessages.FileTooLarge, Math.Round((decimal)Settings.MaxFileSize / 1024 / 1024, 2)));
        }

        public static void ValidateFile(string fullFileName, long? fileSize = null)
        {
            if (fullFileName.IsBlank())
                throw new AppException(AppMessages.FileNameNotFound);

            var lastDotPosition = fullFileName.LastIndexOf(".", StringComparison.Ordinal);

            var fileName = fullFileName.Substring(0, lastDotPosition);
            if (fileName.Length > Settings.MaxFileNameLength)
                throw new AppException(string.Format(AppMessages.FileNameTooLong, Settings.MaxFileNameLength));

            var fileType = Path.GetExtension(fullFileName);
            if (fileType.IsBlank() || !AllowedFileTypes.Contains(fileType.ToLower()))
                throw new AppException(AppMessages.FileTypeNotSupported);

            if (fileSize.GetValueOrDefault() > Settings.MaxFileSize)
                throw new AppException(string.Format(AppMessages.FileTooLarge, Math.Round((decimal)Settings.MaxFileSize / 1024 / 1024, 2)));
        }

        protected string GetOrCreateLeaguerFolder(string childPath, int leaguerId)
        {
            var folderPath = Path.Combine("Contents", "Uploads", leaguerId.ToString(), childPath);
            if (Directory.Exists(folderPath))
                return folderPath;
            Directory.CreateDirectory(folderPath);
            return folderPath;
        }

        protected string GetOrCreateDocumentationFolder(string childPath, int documentationId)
        {
            var folderPath = Path.Combine("Contents", "Uploads", childPath, documentationId.ToString());
            if (Directory.Exists(folderPath))
                return folderPath;
            Directory.CreateDirectory(folderPath);
            return folderPath;
        }


        public async Task<T> GetOrThrow<T>(IRepository<T> repository, int id, string message) where T : class
        {
            if (id <= 0)
                return null;

            //using var unitOfWork = UnitOfWorkFactory.Invoke();
            return await repository.FindAsync(id) ?? throw new AppException(message);
        }

        public async Task<LoadResult> LoadAsync<T>(IQueryable<T> source, DataSourceLoadOptionsBase options) where T : class
        {
            return await DataSourceLoader.LoadAsync(source, options);
        }

        public LoadResult LoadCustom<T>(IList<T> source, DataSourceLoadOptionsBase options) where T : class
        {
            return DataSourceLoader.Load(source, options);
        }

        public void Dispose()
        {
            Console.WriteLine($@"{GetType().Name} disposing...");
        }
    }
}
