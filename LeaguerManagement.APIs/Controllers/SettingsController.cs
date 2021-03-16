using System.Collections.Generic;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.ViewModels.Settings;
using LeaguerManagement.Entities.ViewModels.Shared;
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
        public async Task<bool> AddAccessControl([FromBody] AccessControlModel input)
        {
            return await _settingService.AddAccessControl(input);
        }

        [HttpPut("access-controls")]
        public async Task<bool> UpdateDepartment([FromBody] AccessControlModel input)
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

        #region District

        [HttpPost("districts/search")]
        public async Task<LoadResult> GetDistricts(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetDistricts(loadOptions);
        }

        [HttpPost("districts")]
        public async Task<bool> AddDistrict([FromBody] DistrictModel input)
        {
            return await _settingService.AddDistrict(input);
        }

        [HttpPut("districts")]
        public async Task<bool> UpdateDistrict([FromBody] DistrictModel input)
        {
            return await _settingService.UpdateDistrict(input);
        }

        [HttpDelete("districts/{id:int}")]
        public async Task<bool> DeleteDistrict([FromRoute] int id)
        {
            return await _settingService.DeleteDistrict(id);
        }

        #endregion

        #region Ward

        [HttpPost("wards/search")]
        public async Task<LoadResult> GetWards(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetWards(loadOptions);
        }

        [HttpPost("wards/district/{districtId}")]
        public async Task<LoadResult> GetWardsByDistrict([FromBody] DataSourceLoadOptionsBase loadOptions, [FromRoute] int districtId)
        {
            return await _settingService.GetWardsByDistrict(loadOptions, districtId);
        }

        [HttpPost("wards")]
        public async Task<bool> AddWard([FromBody] WardModel input)
        {
            return await _settingService.AddWard(input);
        }

        [HttpPut("wards")]
        public async Task<bool> UpdateWard([FromBody] WardModel input)
        {
            return await _settingService.UpdateWard(input);
        }

        [HttpDelete("wards/{id:int}")]
        public async Task<bool> DeleteWard([FromRoute] int id)
        {
            return await _settingService.DeleteWard(id);
        }

        #endregion

        #region Street

        [HttpPost("streets/search")]
        public async Task<LoadResult> GetStreets(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetStreets(loadOptions);
        }

        [HttpPost("streets")]
        public async Task<bool> AddStreet([FromBody] StreetModel input)
        {
            return await _settingService.AddStreet(input);
        }

        [HttpPut("streets")]
        public async Task<bool> UpdateStreet([FromBody] StreetModel input)
        {
            return await _settingService.UpdateStreet(input);
        }

        [HttpDelete("streets/{id:int}")]
        public async Task<bool> DeleteStreet([FromRoute] int id)
        {
            return await _settingService.DeleteStreet(id);
        }

        #endregion

        #region Apartment

        [HttpPost("apartments/search")]
        public async Task<LoadResult> GetApartments(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetApartments(loadOptions);
        }

        [HttpPost("apartments")]
        public async Task<bool> AddApartment([FromBody] ApartmentModel input)
        {
            return await _settingService.AddApartment(input);
        }

        [HttpPut("apartments")]
        public async Task<bool> UpdateApartment([FromBody] ApartmentModel input)
        {
            return await _settingService.UpdateApartment(input);
        }

        [HttpDelete("apartments/{id:int}")]
        public async Task<bool> DeleteApartment([FromRoute] int id)
        {
            return await _settingService.DeleteApartment(id);
        }

        #endregion

        #region Notification

        [HttpPost("notifications/search")]
        public async Task<LoadResult> GetNotifications(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetNotifications(loadOptions);
        }

        [HttpPost("notifications")]
        public async Task<bool> AddNotification([FromBody] NotificationModel input)
        {
            return await _settingService.AddNotification(input);
        }

        [HttpPut("notifications")]
        public async Task<bool> UpdateNotification([FromBody] NotificationModel input)
        {
            return await _settingService.UpdateNotification(input);
        }

        [HttpDelete("notifications/{id:int}")]
        public async Task<bool> DeleteNotification([FromRoute] int id)
        {
            return await _settingService.DeleteNotification(id);
        }

        #endregion

        #region DocumentTypes

        [HttpPost("document-types/search")]
        public async Task<LoadResult> GetDocumentTypes(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetDocumentTypes(loadOptions);
        }

        [HttpPost("document-types")]
        public async Task<bool> AddDocumentType([FromBody] DocumentTypeModel input)
        {
            return await _settingService.AddDocumentType(input);
        }

        [HttpPut("document-types")]
        public async Task<bool> UpdateDocumentType([FromBody] DocumentTypeModel input)
        {
            return await _settingService.UpdateDocumentType(input);
        }

        [HttpDelete("document-types/{id:int}")]
        public async Task<bool> DeleteDocumentType([FromRoute] int id)
        {
            return await _settingService.DeleteDocumentType(id);
        }

        #endregion

        #region CertificateTypes

        [HttpPost("certificate-types/search")]
        public async Task<LoadResult> GetCertificateTypes(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetCertificateTypes(loadOptions);
        }

        [HttpPost("certificate-types")]
        public async Task<bool> AddCertificateType([FromBody] CertificateTypeModel input)
        {
            return await _settingService.AddCertificateType(input);
        }

        [HttpPut("certificate-types")]
        public async Task<bool> UpdateCertificateType([FromBody] CertificateTypeModel input)
        {
            return await _settingService.UpdateCertificateType(input);
        }

        [HttpDelete("certificate-types/{id:int}")]
        public async Task<bool> DeleteCertificateType([FromRoute] int id)
        {
            return await _settingService.DeleteCertificateType(id);
        }

        #endregion

        #region CopyTypes

        [HttpPost("copy-types/search")]
        public async Task<LoadResult> GetCopyTypes(DataSourceLoadOptionsBase loadOptions)
        {
            return await _settingService.GetCopyTypes(loadOptions);
        }

        [HttpPost("copy-types")]
        public async Task<bool> AddCopyType([FromBody] CopyTypeModel input)
        {
            return await _settingService.AddCopyType(input);
        }

        [HttpPut("copy-types")]
        public async Task<bool> UpdateCopyType([FromBody] CopyTypeModel input)
        {
            return await _settingService.UpdateCopyType(input);
        }

        [HttpDelete("copy-types/{id:int}")]
        public async Task<bool> DeleteCopyType([FromRoute] int id)
        {
            return await _settingService.DeleteCopyType(id);
        }

        #endregion

        #region Holidays 

        [HttpPost("holidays/search/{year}")]
        public async Task<LoadResult> GetHolidays([FromBody] DataSourceLoadOptionsBase loadOptions, [FromRoute]int year)
        {
            return await _settingService.GetHolidays(loadOptions, year);
        }

        [HttpGet("holidays/settings/{year}")]
        public async Task<IList<HolidayModel>> GetHolidaySettings([FromRoute] int year)
        {
            return await _settingService.GetHolidaySettings(year);
        }

        [HttpPost("holidays/settings")]
        public async Task<bool> AddHolidaySettings([FromBody] HolidayModel input)
        {
            return await _settingService.AddHolidaySettings(input);
        }

        [HttpPut("holidays/settings")]
        public async Task<bool> UpdateHolidaySettings([FromBody] HolidayModel input)
        {
            return await _settingService.UpdateHolidaySettings(input);
        }

        [HttpPost("holidays")]
        public async Task<bool> AddHoliday([FromBody] HolidayModel input)
        {
            return await _settingService.AddHoliday(input);
        }

        [HttpPut("holidays")]
        public async Task<bool> UpdateHoliday([FromBody] HolidayModel input)
        {
            return await _settingService.UpdateHoliday(input);
        }

        [HttpDelete("holidays/{id:int}")]
        public async Task<bool> DeleteHoliday([FromRoute] int id)
        {
            return await _settingService.DeleteHoliday(id);
        }


        #endregion
    }
}