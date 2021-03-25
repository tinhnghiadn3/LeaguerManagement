using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities.Extension;
using Microsoft.AspNetCore.Http;

namespace LeaguerManagement.Entities.Utilities.Helper
{
    public static class FileHelper
    {
        private static readonly string[] AllowedFileTypes = { ".jpg", ".jpeg", ".png", ".gif" };
        //private static readonly string Base64ImagePrefix = "data:image/";

        public static string GetValidFileName(this IFormFile file)
        {
            // validate file
            var fileName = file.Name.RemoveVietnameseSigns();

            if (StringExtensions.IsBlank(fileName))
                throw new AppException(AppMessages.FileNameIsIncorrect);

            var fileType = Path.GetExtension(fileName);
            if (StringExtensions.IsBlank(fileType) || !((IList)AllowedFileTypes).Contains(fileType.ToLower()))
                throw new AppException(AppMessages.FileTypeNotSupported);

            return fileName;
        }

        public static string GetExtension(string path)
        {
            return Path.GetExtension(path).ToLowerInvariant();
        }

        //private static Dictionary<string, string> GetMimeTypes()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {".png", "image/png"},
        //        {".jpg", "image/jpeg"},
        //        {".jpeg", "image/jpeg"},
        //        {".gif", "image/gif"},
        //    };
        //}

        public static string UploadFile(string folderPath, IFormFile file, string fileName, out string filePath)
        {
            if (file.Length <= 0)
            {
                filePath = string.Empty;
                return string.Empty;
            }

            filePath = Path.Combine(folderPath, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return "/images/" + fileName;
        }

        public static bool DeleteFile(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath)) return false;
            try
            {
                if (File.Exists(dirPath))
                    File.Delete(dirPath);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
