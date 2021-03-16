using System.Linq;
using LeaguerManagement.Entities.Utilities.Helper;
using Microsoft.AspNetCore.Http;

namespace LeaguerManagement.Entities.Utilities
{
    public static class HttpContextExtensions
    {
        private static string GetClaimValue(HttpContext context, string claimName)
        {
            return context.User.Claims.FirstOrDefault(x => x.Type == claimName)?.Value;
        }

        public static int UserId(this HttpContext context)
        {
            return GetClaimValue(context, "UserId").ToInt();
        }

        public static int RoleId(this HttpContext context)
        {
            return GetClaimValue(context, "RoleId").ToInt();
        }

        public static int UnitId(this HttpContext context)
        {
            return GetClaimValue(context, "UnitId").ToInt();
        }

        public static int DepartmentId(this HttpContext context)
        {
            return GetClaimValue(context, "DepartmentId").ToInt();
        }

        public static int DepartmentTypeId(this HttpContext context)
        {
            return GetClaimValue(context, "DepartmentTypeId").ToInt();
        }

        public static string AccessToken(this HttpContext context)
        {
            return GetToken(context?.Request?.Headers?["Authorization"]);
        }

        private static string GetToken(string authorizationHeader)
        {
            if (authorizationHeader == null)
            {
                return null;
            }

            var arr = authorizationHeader.Split(" ");
            if (arr.Length != 2 || arr[1] == "null")
            {
                return null;
            }

            return arr[1];
        }
    }
}
