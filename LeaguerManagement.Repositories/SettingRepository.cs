using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Contexts;
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

        #region Ward

        public static async Task<bool> IsDuplicated(this IRepository<Ward> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static IQueryable<WardModel> GetWardsQuery(this IRepository<Ward> repository)
        {
            var db = (LandStatusConfirmationContext)repository.DbContext;
            return from w in db.Ward
                join d in db.District on w.DistrictId equals d.Id
                select new WardModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    DistrictId = d.Id,
                };
        }

        public static IQueryable<WardModel> GetWardsByDistrictQuery(this IRepository<Ward> repository, int districtId)
        {
            var db = (LandStatusConfirmationContext)repository.DbContext;
            return from w in db.Ward
                where w.DistrictId == districtId
                select new WardModel
                {
                    Id = w.Id,
                    Name = w.Name
                };
        }

        #endregion

        #region Holiday

        public static async Task<IList<Holiday>> GetListHolidaySettings(this IRepository<Holiday> repository, int year)
        {
            return await repository.Entities.Where(_ => _.IsSettings != null && _.IsSettings.Value && _.Date.Year == year).ToListAsync();
        }
        public static async Task<Holiday> GetHolidaySettings(this IRepository<Holiday> repository, int year)
        {
            return await repository.Entities.FirstOrDefaultAsync(_ => _.IsSettings != null && _.IsSettings.Value && _.Date.Year == year);
        }

        public static async Task<IList<Holiday>> GetHolidays(this IRepository<Holiday> repository, int year)
        {
            return await repository.Entities.Where(_ => _.IsSettings != null && !_.IsSettings.Value && _.Date.Year == year).ToListAsync();
        }

        #endregion

        #region District - Street - Apartment - Notification - DocumentType - CopyType

        public static async Task<bool> IsDuplicated(this IRepository<District> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<Street> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<Apartment> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<Notification> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<DocumentType> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<CopyType> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<CertificateType> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<bool> IsDuplicated(this IRepository<Holiday> repository, int id, string name, DateTime date)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && (_.Name.ToLower() == name.ToLower() || _.Date == date));
        }

        #endregion
    }
}
