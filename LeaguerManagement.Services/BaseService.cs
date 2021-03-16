using System;
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

        private static readonly string[] _allowedFileTypes = { ".jpg", ".jpeg", ".png", ".gif" };


        public BaseService(Func<IUnitOfWork> unitOfWorkFactory, IOptionsSnapshot<GlobalSettings> settings)
        {
            Settings = settings.Value;
            UnitOfWorkFactory = unitOfWorkFactory;
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
            if (fileType.IsBlank() || !_allowedFileTypes.Contains(fileType.ToLower()))
                throw new AppException(AppMessages.FileTypeNotSupported);

            if (fileSize.GetValueOrDefault() > Settings.MaxFileSize)
                throw new AppException(string.Format(AppMessages.FileTooLarge, Math.Round((decimal)Settings.MaxFileSize / 1024 / 1024, 2)));
        }

        protected string GetOrCreateConstructionFolder(string childPath, int fileId)
        {
            var folderPath = Path.Combine("Contents", "Uploads", fileId.ToString(), childPath);
            if (Directory.Exists(folderPath))
                return folderPath;
            Directory.CreateDirectory(folderPath);
            return folderPath;
        }

        //protected async Task<File> GetOrCreateFolder(string name, string parentId)
        //{
        //    //
        //    // Find folder by name in parent folder.
        //    var listRequest = DriveService.Files.List();
        //    listRequest.Spaces = "drive";
        //    listRequest.PageSize = 1;
        //    listRequest.Fields = $"nextPageToken, files({_fileFields})";
        //    listRequest.Q = $"trashed = false and name='{name}'";
        //    if (parentId != null)
        //    {
        //        listRequest.Q += $" and '{parentId}' in parents";
        //    }
        //    var result = await listRequest.ExecuteAsync();
        //    if (result.Files.Any())
        //    {
        //        return result.Files.First();
        //    }
        //    //
        //    // Create new folder
        //    var fileMetadata = new File
        //    {
        //        Name = name,
        //        MimeType = "application/vnd.google-apps.folder",
        //        Parents = parentId == null ? null : new List<string> { parentId }
        //    };
        //    var request = DriveService.Files.Create(fileMetadata);
        //    request.Fields = _fileFields;

        //    return request.Execute();
        //}


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
