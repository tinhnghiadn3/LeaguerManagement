using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Repositories
{
    public static class LeaguerRepository
    {
        public static async Task<List<LeaguerModel>> GetCurrentLeaguers(this IRepository<Leaguer> repository)
        {
            var source = new List<LeaguerModel>();
            await repository.LoadStoredProc("spGetCurrentLeaguers")
                .ExecuteStoredProcAsync((result) =>
                {
                    source = result.ReadNextListOrEmpty<LeaguerModel>().ToList();
                });

            return source;
        }

        public static async Task<List<LeaguerModel>> GetAllLeaguers(this IRepository<Leaguer> repository)
        {
            var source = new List<LeaguerModel>();
            await repository.LoadStoredProc("spGetAllLeaguers")
                .ExecuteStoredProcAsync((result) =>
                {
                    source = result.ReadNextListOrEmpty<LeaguerModel>().ToList();
                });

            return source;
        }

        public static async Task<bool> IsExistingLeaguer(this IRepository<Leaguer> repository, string name, string cardNumber, int id = 0)
        {
            return await repository.Entities.AnyAsync(_ =>
                _.Id != id && string.Equals(_.Name, name) && string.Equals(_.CardNumber, cardNumber));
        }
    }
}
