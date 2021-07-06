using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LeaguerManagement.APIs.Configurations
{
    public class FileAuthorizeAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Authorize that the current request with the image token in sc param
        /// </summary>
        public FileAuthorizeAttribute() : base(typeof(FileAuthorizeFilter)) { }
    }

    public class FileAuthorizeFilter : IAuthorizationFilter
    {
        private static TokenValidationParameters _tokenValidationParameters;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Query.TryGetValue("sc", out var sc);
            var imageToken = sc.FirstOrDefault();

            if (string.IsNullOrEmpty(imageToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userToken = UserTokenHelper.GetUserToken(imageToken, TokenType.ImageToken);
            if (userToken == null || userToken.IsRevoked)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var parameters = GetTokenValidationParameters(context);
            //
            // Validate token
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claimsPrincipal = handler.ValidateToken(userToken.Token, parameters, out var sercurityToken);
                var claimsIdentity = new ClaimsIdentity(claimsPrincipal.Claims);
                context.HttpContext.User.AddIdentity(claimsIdentity);
            }
            catch (SecurityTokenValidationException)
            {
                //
                // The token failed validation
                context.Result = new UnauthorizedResult();
            }
            catch (ArgumentException)
            {
                //
                // The token was not well-formed or was invalid for some other reason.
                context.Result = new UnauthorizedResult();
            }
        }

        private static TokenValidationParameters GetTokenValidationParameters(AuthorizationFilterContext context)
        {
            if (_tokenValidationParameters != null)
                return _tokenValidationParameters;

            var settings = context.HttpContext.RequestServices.GetService<IOptionsSnapshot<GlobalSettings>>().Value;

            return _tokenValidationParameters = InitParameters(settings.Token.TokenSecretKey);
        }

        public static TokenValidationParameters InitParameters(string tokenSecretKey)
        {
            var tokenKey = Encoding.ASCII.GetBytes(tokenSecretKey);

            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
