using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Extension;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentationsController : BaseController
    {
        private readonly GlobalSettings _settings;
        private readonly DocumentationService _documentationService;

        public DocumentationsController(DocumentationService documentationService, IOptionsSnapshot<GlobalSettings> settings)
        {
            _documentationService = documentationService;
            _settings = settings.Value;
        }

        [HttpGet]
        public Task<IList<ReferenceWithAttachmentModel<BaseSettingModel>>> GetDocumentations()
        {
            return _documentationService.GetDocumentations();
        }

        [HttpPost]
        public Task<int> AddLeaguer(BaseSettingModel input)
        {
            return _documentationService.AddDocumentation(input);
        }

        [HttpPut]
        public Task<bool> UpdateLeaguer(BaseSettingModel input)
        {
            return _documentationService.UpdateDocumentation(input);
        }

        [HttpDelete("{id:int}")]
        public Task<bool> DeleteLeaguer(int id)
        {
            return _documentationService.DeleteDocumentation(id);
        }

        [HttpPost("{documentationId:int}/attachments")]
        public async Task<IList<AttachmentModel>> PostAvatarAsync([FromRoute] int documentationId)
        {
            var files = Request.Form.Files;

            if (files == null || !files.Any())
                throw new AppException(AppMessages.NoFildeToUpload);

            if (files.Count > _settings.MaxFilesPerRequest)
                throw new AppException(AppMessages.TooManyFilesToUpload);

            var attachments = new List<AttachmentModel>();

            foreach (var file in files)
            {
                // Format file name
                var fileName = file.Name.RemoveVietnameseSigns();

                // Save file
                var savedFile = await _documentationService.SaveAttachment(documentationId, fileName, file);
                attachments.Add(savedFile);
            }

            attachments.Reverse();

            return attachments;
        }

        [HttpPost("documentation/attachments/rename")]
        public Task<AttachmentModel> RenameAttachmentAsync([FromBody] RenameAttachmentModel input)
        {
            return _documentationService.RenameAttachment(input.AttachmentId, input.NewName, input.ReferenceId);
        }

        [HttpDelete("documentation/{documentationId:int}/attachments/{attachmentId}")]
        public Task<bool> DeleteAttachmentAsync([FromRoute] int documentationId, [FromRoute] int attachmentId)
        {
            return _documentationService.DeleteAttachmentAsync(documentationId, attachmentId);
        }

    }
}
