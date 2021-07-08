using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController : BaseController
    {
        private readonly SettingService _settingService;

        public SettingsController(SettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet("lookup")]
        public async Task<LookupModel> GetLookup([FromQuery] string keys)
        {
            return await _settingService.GetLookup(keys);
        }

        #region Role

        [HttpPost("roles/search")]
        public async Task<LoadResult> GetRoles(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetRoles(loadOptions);
        }

        [HttpPost("roles")]
        public async Task<bool> AddRole([FromBody] RoleModel input)
        {
            return await _settingService.AddRole(input);
        }

        [HttpPut("roles")]
        public async Task<bool> UpdateRole([FromBody] RoleModel input)
        {
            return await _settingService.UpdateRole(input);
        }

        [HttpDelete("roles/{id:int}")]
        public async Task<bool> DeleteRole([FromRoute] int id)
        {
            return await _settingService.DeleteRole(id);
        }

        #endregion

        #region Access control

        [HttpPost("access-controls/search")]
        public async Task<LoadResult> GetAccessControls(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetAccessControls(loadOptions);
        }

        [HttpPost("access-controls")]
        public async Task<bool> AddAccessControl([FromBody] BaseSettingModel input)
        {
            return await _settingService.AddAccessControl(input);
        }

        [HttpPut("access-controls")]
        public async Task<bool> UpdateDepartment([FromBody] BaseSettingModel input)
        {
            return await _settingService.UpdateAccessControl(input);
        }

        [HttpDelete("access-controls/{id:int}")]
        public async Task<bool> DeleteAccessControl([FromRoute] int id)
        {
            return await _settingService.DeleteAccessControl(id);
        }

        #endregion

        #region AccessOfRole

        [HttpPost("access-role")]
        public async Task<bool> UpdateAccessOfRole(AccessOfRoleModel input)
        {
            return await _settingService.UpdateAccessOfRole(input);
        }

        #endregion

        #region User

        [HttpPost("users/search")]
        public async Task<LoadResult> GetUsers(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetUsers(loadOptions);
        }

        [HttpPost("users")]
        public async Task<bool> AddUser([FromBody] UserModel input)
        {
            return await _settingService.AddUser(input);
        }

        [HttpPut("users")]
        public async Task<bool> UpdateUser([FromBody] UserModel input)
        {
            return await _settingService.UpdateUser(input);
        }

        [HttpDelete("users/{id:int}")]
        public async Task<bool> DeleteUser([FromRoute] int id)
        {
            return await _settingService.DeleteUser(id);
        }

        #endregion

        #region ChangeOfficialDocumentType

        [HttpPost("official-document-types/search")]
        public async Task<LoadResult> GetChangeOfficialDocumentTypes(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetChangeOfficialDocumentTypes(loadOptions);
        }

        [HttpPost("official-document-types")]
        public async Task<bool> AddChangeOfficialDocumentType([FromBody] BaseSettingModel input)
        {
            return await _settingService.AddChangeOfficialDocumentType(input);
        }

        [HttpPut("official-document-types")]
        public async Task<bool> UpdateChangeOfficialDocumentType([FromBody] BaseSettingModel input)
        {
            return await _settingService.UpdateChangeOfficialDocumentType(input);
        }

        [HttpDelete("official-document-types/{id:int}")]
        public async Task<bool> DeleteChangeOfficialDocumentType([FromRoute] int id)
        {
            return await _settingService.DeleteChangeOfficialDocumentType(id);
        }

        #endregion

        #region ChangeOfficialDocument

        [HttpPost("official-documents/search")]
        public async Task<LoadResult> GetChangeOfficialDocuments(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetChangeOfficialDocuments(loadOptions);
        }

        [HttpPost("official-documents")]
        public async Task<bool> AddChangeOfficialDocument([FromBody] ChangeOfficialDocumentModel input)
        {
            return await _settingService.AddChangeOfficialDocument(input);
        }

        [HttpPut("official-documents")]
        public async Task<bool> UpdateChangeOfficialDocument([FromBody] ChangeOfficialDocumentModel input)
        {
            return await _settingService.UpdateChangeOfficialDocument(input);
        }

        [HttpDelete("official-documents/{id:int}")]
        public async Task<bool> DeleteChangeOfficialDocument([FromRoute] int id)
        {
            return await _settingService.DeleteChangeOfficialDocument(id);
        }

        #endregion

    }
}