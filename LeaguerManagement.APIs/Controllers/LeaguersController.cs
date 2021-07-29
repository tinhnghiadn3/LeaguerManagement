using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Extension;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaguersController : BaseController
    {
        private readonly LeaguerService _leaguerService;
        private readonly GlobalSettings _settings;

        public LeaguersController(LeaguerService leaguerService, IOptionsSnapshot<GlobalSettings> settings)
        {
            _leaguerService = leaguerService;
            _settings = settings.Value;
        }

        [HttpPost("current")]
        public async Task<LoadResult> GetCurrentLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            return await _leaguerService.GetCurrentLeaguers(loadOptions);
        }

        [HttpPost("search")]
        public async Task<LoadResult> GetAllLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            return await _leaguerService.GetAllLeaguers(loadOptions);
        }

        [HttpGet("statistic")]
        public async Task<IList<StatusStatisticModel>> GetStatusStatistics()
        {
            return await _leaguerService.GetStatusStatistics();
        }

        [HttpGet("{id:int}/detail")]
        public async Task<ReferenceWithAttachmentModel<LeaguerModel>> GetLeaguerDetail([FromRoute] int id)
        {
            return await _leaguerService.GetLeaguerDetail(id);
        }

        [HttpPost("check")]
        public async Task<bool> CheckExistLeaguer([FromBody] CheckExistDataModel input)
        {
            return await _leaguerService.CheckExistLeaguer(input);
        }

        [HttpPost]
        public async Task<int> AddLeaguer(LeaguerModel input)
        {
            return await _leaguerService.AddLeaguer(input);
        }

        [HttpPut]
        public async Task<bool> UpdateLeaguer(LeaguerModel input)
        {
            return await _leaguerService.UpdateLeaguer(input);
        }

        [HttpDelete("{id:int}")]
        public async Task<bool> DeleteLeaguer(int id)
        {
            return await _leaguerService.DeleteLeaguer(id);
        }

        // export excel

        [HttpGet("export")]
        public async Task<IActionResult> ExportCopyReturningPaper()
        {
            var stream = await _leaguerService.ExportExcelAllLeager();

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        // change status

        [HttpGet("{id:int}/change/official")]
        public async Task<bool> ChangeToOfficial([FromRoute] int id)
        {
            return await _leaguerService.ChangeToOfficial(id);
        }

        [HttpGet("{id:int}/change/out")]
        public async Task<bool> ChangeToOut([FromRoute] int id)
        {
            return await _leaguerService.ChangeToOut(id);
        }

        [HttpGet("{id:int}/change/dead")]
        public async Task<bool> ChangeToDead([FromRoute] int id)
        {
            return await _leaguerService.ChangeToDead(id);
        }

        // attachment change to official

        [HttpGet("{id:int}/official-documents")]
        public async Task<IList<ReferenceWithAttachmentModel<AppliedDocumentModel>>> GetOfficialDocuments([FromRoute] int id)
        {
            return await _leaguerService.GetOfficialDocuments(id);
        }

        // avatar

        [HttpPost("{leaguerId:int}/avatars")]
        public async Task<IList<AttachmentModel>> PostAvatarAsync([FromRoute] int leaguerId)
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
                var savedFile = await _leaguerService.SaveAttachment(leaguerId, fileName, file, true);
                attachments.Add(savedFile);
            }

            attachments.Reverse();

            return attachments;
        }

        // attachments

        [HttpPost("{leaguerId:int}/attachments")]
        public async Task<IList<AttachmentModel>> PostFileAsync([FromRoute] int leaguerId)
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
                var savedFile = await _leaguerService.SaveAttachment(leaguerId, fileName, file, false);
                attachments.Add(savedFile);
            }

            attachments.Reverse();

            return attachments;
        }

        [HttpPost("general/attachments/rename")]
        public async Task<AttachmentModel> RenameAttachmentAsync([FromBody] RenameAttachmentModel input)
        {
            return await _leaguerService.RenameAttachment(input.AttachmentId, input.NewName, input.ReferenceId);
        }

        [HttpDelete("general/{leaguerId:int}/attachments/{attachmentId}")]
        public async Task<bool> DeleteAttachmentAsync([FromRoute] int leaguerId, [FromRoute] int attachmentId)
        {
            return await _leaguerService.DeleteAttachmentAsync(leaguerId, attachmentId);
        }

        // officials

        [HttpPost("{appliedId:int}/officials")]
        public async Task<IList<AttachmentModel>> PostDocumentAsync([FromRoute] int appliedId)
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
                var savedFile = await _leaguerService.SaveAppliedAttachment(appliedId, fileName, file);
                attachments.Add(savedFile);
            }

            attachments.Reverse();

            return attachments;
        }

        [HttpPost("official/attachments/rename")]
        public async Task<AttachmentModel> RenameOfficialAttachment([FromBody] RenameAttachmentModel input)
        {
            return await _leaguerService.RenameOfficialAttachment(input.AttachmentId, input.NewName, input.ReferenceId);
        }

        [HttpDelete("official/{appliedId:int}/attachments/{attachmentId}")]
        public async Task<bool> DeleteOfficialAttachmentAsync([FromRoute] int appliedId, [FromRoute] int attachmentId)
        {
            return await _leaguerService.DeleteOfficialAttachmentAsync(appliedId, attachmentId);
        }
    }
}