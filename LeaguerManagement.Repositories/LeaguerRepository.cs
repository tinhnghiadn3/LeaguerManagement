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

        public static async Task<ReferenceWithAttachmentModel<LeaguerModel>> GetLeaguerDetail(this IRepository<Leaguer> repository, int id)
        {
            var source = new ReferenceWithAttachmentModel<LeaguerModel>();
            await repository.LoadStoredProc("spGetLeaguer")
                .WithSqlParam("@Id", id)
                .ExecuteStoredProcAsync((result) =>
                {
                    source.Reference = result.ReadNextListOrEmpty<LeaguerModel>().FirstOrDefault();

                    if (source.Reference == null) return;

                    var avatar = result.ReadNextListOrEmpty<AttachmentModel>().FirstOrDefault();
                    if (avatar != null) source.Reference.AvatarId = avatar.Id;

                    source.Attachments = result.ReadNextListOrEmpty<AttachmentModel>().ToList();

                    source.TotalAttachments = source.Attachments.Count;
                });

            return source;
        }

        public static async Task<int> GetCurrentAvatarId(this IRepository<LeaguerAttachment> repository, int leaguerId)
        {
            var avatar = await repository.Entities.FirstOrDefaultAsync(_ => _.LeaguerId == leaguerId && _.IsAvatar);
            return avatar?.Id ?? 0; 
        }
    }
}
