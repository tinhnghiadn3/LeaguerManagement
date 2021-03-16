using System.Threading.Tasks;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.ViewModels.Authentication;
using LeaguerManagement.Entities.ViewModels.Shared;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : BaseController
    {
        private readonly UserService _userService;
        public AuthenticationController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<AuthenticationUserModel> LoginAsync([FromBody]LoginModel input)

        {
            return await _userService.Login(input);
        }

        [HttpPost("email/duplicate")]
        public async Task<bool> IsEmailDuplicated([FromBody]SingleFieldModel<string> input)
        {
            return await _userService.IsEmailDuplicated(input);
        }

        [HttpGet("current-user")]
        public async Task<LoggedUserModel> CurrentUser()
        {
            return await _userService.CurrentUser();
        }

        [HttpPost("change")]
        public async Task<bool> ChangePasswordAsync([FromBody]ChangePasswordModel model)
        {
            return await _userService.ChangePassword(model);
        }

        [HttpGet("logout")]
        public async Task<bool> Logout()
        {
            var accessToken = HttpContext.AccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                return false;
            }
            //
            // Revoke token
            await _userService.RevokeToken(accessToken);

            return true;
        }

        [AllowAnonymous]
        [HttpGet]
        public bool Get()
        {
            return true;
        }
    }
}
