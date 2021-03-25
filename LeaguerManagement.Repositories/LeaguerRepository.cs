using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels.Leaguers;
using LeaguerManagement.Repositories.Extensions;

namespace LeaguerManagement.Repositories
{
    public static class LeaguerRepository
    {
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
    }
}
