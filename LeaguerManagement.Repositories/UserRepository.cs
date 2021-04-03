using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Contexts;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Repositories
{
    public static class UserRepository
    {
        public static async Task<User> FindUser(this IRepository<User> repository, string email)
        {
            return await repository.Entities.FirstOrDefaultAsync(_ => _.Email == email);
        }

        public static IQueryable<UserModel> GetUsers(this IRepository<User> repository)
        {
            var db = (LeaguerManagementContext)repository.DbContext;
            return from u in db.Users
                join ur in db.UserRoles on u.Id equals ur.UserId
                where ur.IsActivated
                select new UserModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    RoleId = ur.RoleId
                };
        }

        public static async Task<bool> IsDuplicated(this IRepository<User> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<LoggedUserModel> GetCurrentUser(this IRepository<User> repository, int? userId = null)
        {
            var user = new LoggedUserModel();
            await repository.LoadStoredProc("spGetCurrentUser")
                .WithSqlParam("@UserId", userId ?? repository.CurrentUser.UserId)
                .ExecuteStoredProcAsync((result) =>
                {
                    user = result.ReadNextListOrEmpty<LoggedUserModel>().FirstOrDefault();
                    user.AccessControlIds = result.ReadNextListOrEmpty<SingleFieldModel<int>>().Select(_ => _.Id).ToList();
                });

            return user;
        }

        public static async Task<bool> IsUserEmailDuplicated(this IRepository<User> repository, int userId, string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return await repository.Entities.AnyAsync(_ =>
                _.Id != userId && !string.IsNullOrEmpty(_.Email) &&
                _.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        public static async Task<IList<UserRole>> GetUserRoles(this IRepository<UserRole> repository, int userId)
        {
            return await repository.Entities.ToListAsync(_ => _.UserId == userId);
        }

        public static async Task<UserRole> GetActivatedUserRole(this IRepository<UserRole> repository, int userId)
        {
            return await repository.Entities.FirstOrDefaultAsync(_ => _.UserId == userId && _.IsActivated);
        }

        public static async Task<UserRole> GetUnactivatedUserRole(this IRepository<UserRole> repository, int userId, int roleId)
        {
            return await repository.Entities.FirstOrDefaultAsync(_ =>
                _.UserId == userId && _.RoleId == roleId && !_.IsActivated);
        }

        public static async Task<IList<UserToken>> GetTokens(this IRepository<UserToken> repository)
        {
            return (await repository.GetAllAsync()).ToList();
        }

        public static async Task RevokeToken(this IRepository<UserToken> repository, int id)
        {
            await repository.DbContext.LoadStoredProc("spRevokeToken")
                .WithSqlParam("@id", id)
                .ExecuteStoredProcAsync((result) => { });
        }

        public static async Task RemoveExpiredTokens(this IRepository<UserToken> repository)
        {
            var now = DateTime.Now;

            UserTokenHelper.RemoveExpiredTokens(now);

            await repository.DbContext.LoadStoredProc("spRemoveExpiredTokens")
                .WithSqlParam("@dateExpired", now)
                .ExecuteStoredProcAsync((result) => { });
        }
    }
}
