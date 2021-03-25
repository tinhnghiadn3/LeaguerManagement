using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels.Settings;
using LeaguerManagement.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Repositories
{
    public static class SettingRepository
    {
        #region Role

        public static async Task<bool> IsDuplicated(this IRepository<Role> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<IList<RoleModel>> GetRoles(this IRepository<Role> repository)
        {
            var source = new List<RoleModel>();
            await repository.LoadStoredProc("spGetRoles")
                .ExecuteStoredProcAsync((result) =>
                {
                    source = result.ReadNextListOrEmpty<RoleModel>().ToList();
                    var accessOfRole = result.ReadNextListOrEmpty<AccessOfRoleModel>();
                    foreach (var role in source)
                    {
                        role.AccessControlIds = accessOfRole.Where(_ => _.RoleId == role.Id).Select(a => a.AccessControlId).ToList();
                    }
                });

            return source;
        }

        #endregion

        #region Access Control

        public static async Task<bool> IsDuplicated(this IRepository<AccessControl> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        #endregion

        #region Access Of Role

        public static async Task<AccessOfRole> Get(this IRepository<AccessOfRole> repository, int roleId, int accessControlId)
        {
            return await repository.Entities.FirstOrDefaultAsync(_ => _.RoleId == roleId && _.AccessControlId == accessControlId);
        }

        public static async Task<IList<AccessOfRole>> GetByRole(this IRepository<AccessOfRole> repository, int roleId)
        {
            return await repository.Entities.ToListAsync(_ => _.RoleId == roleId);
        }

        #endregion
    }
}
