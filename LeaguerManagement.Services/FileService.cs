using System;
using System.IO;
using System.Linq;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Extentsion;
using Microsoft.Extensions.Options;
using NLog;

namespace LeaguerManagement.Services
{
    public class FileService : BaseService
    {
        private readonly ILogger _logger;

        public FileService(Func<IUnitOfWork> unitOfWorkFactory, IOptionsSnapshot<GlobalSettings> settings,
            ILogger logger) : base(unitOfWorkFactory, settings)
        {
            _logger = logger;
        }

        public byte[] GetFile(int leaguerId, int attachmentId, string pathType, out string fileName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Contents", "Uploads", leaguerId.ToString(), pathType);
            //
            // Return when folder is not exist
            if (!Directory.Exists(filePath))
            {
                fileName = string.Empty;
                throw new AppException(string.Format(AppMessages.FileNotFound));
            }

            try
            {
                //
                // Get file path from name
                var paths = Directory.GetFiles(filePath, attachmentId + "_*", SearchOption.TopDirectoryOnly);
                if (paths == null || !paths.Any())
                {
                    fileName = null;
                    return null;
                }
                var path = paths.First();
                fileName = Path.GetFileName(path).Replace(attachmentId + "_", "");

                using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                return stream?.ReadAllBytes();
            }
            catch
            {
                //
                // File on writing
                fileName = null;
                return null;
            }
        }

    }
}
