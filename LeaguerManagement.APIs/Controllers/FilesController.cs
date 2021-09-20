using System.IO;
using LeaguerManagement.APIs.Configurations;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [FileAuthorize]
    public class FilesController : BaseController
    {
        private readonly GlobalSettings _settings;
        private const int FiveMB = 5242880;

        private readonly FileService _fileService;

        public FilesController(FileService fileService, IOptionsSnapshot<GlobalSettings> settings)
        {
            _fileService = fileService;
            _settings = settings.Value;
        }    

        [HttpGet("avatar/image")]
        public IActionResult GetAvatar([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Avatar");
        }    

        [HttpGet("general/image")]
        public IActionResult GetGeneralImage([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Information");
        }

        [HttpGet("general/download")]
        public IActionResult DownloadGeneralFile([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Information");
        }

        [HttpGet("official/image")]
        public IActionResult GetOfficialImage([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Official");
        }

        [HttpGet("official/download")]
        public IActionResult DownloadOfficialFile([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Official");
        }

        [HttpGet("documentation/image")]
        public IActionResult GetDocumentationImage([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Documentations", true);
        }

        [HttpGet("documentation/download")]
        public IActionResult DownloadDocumentationFile([FromQuery] int leaId, [FromQuery] int attId)
        {
            return GetServerFile(leaId, attId, "Documentations", true);
        }

        #region Private Method

        private IActionResult GetServerFile(int leaguerId, int attachmentId, string pathType, bool isDocumentation = false)
        {
            var bytes = _fileService.GetFile(leaguerId, attachmentId, pathType, isDocumentation, out var fileName);
            if (bytes == null)
                return null;

            var content = new MemoryStream(bytes);
            //
            // Cache in browser when the file's size is 5 megabytes or lower
            if (bytes.LongLength <= FiveMB)
            {
                var duration = 60 * 60 * _settings.StaticFilesCachedHours;
                Request.HttpContext.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + duration;
            }
            else
            {
                Request.HttpContext.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
                Request.HttpContext.Response.Headers[HeaderNames.Pragma] = "no-cache";
                Request.HttpContext.Response.Headers[HeaderNames.Expires] = "-1";
            }
            //
            // Return response
            return File(content, GetMimeType(fileName), fileName);
        }

        private string GetMimeType(string fileName)
        {
            //
            // Make Sure Microsoft.AspNetCore.StaticFiles Nuget Package is installed
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }

        #endregion

        [HttpGet]
        public bool Get()
        {
            return true;
        }
    }
}