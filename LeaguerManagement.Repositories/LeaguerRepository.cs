using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Contexts;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Repositories
{
    public static class LeaguerRepository
    {
        public static async Task<List<LeaguerModel>> GetCurrentLeaguers(this IRepository<Leaguer> repository, int? unitId)
        {
            var source = new List<LeaguerModel>();
            await repository.LoadStoredProc("spGetCurrentLeaguers")
                .WithSqlParam("@unitId", unitId)
                .ExecuteStoredProcAsync((result) =>
                {
                    source = result.ReadNextListOrEmpty<LeaguerModel>().ToList();
                });

            return source;
        }

        public static async Task<List<LeaguerModel>> GetAllLeaguers(this IRepository<Leaguer> repository, int? unitId)
        {
            var source = new List<LeaguerModel>();
            await repository.LoadStoredProc("spGetAllLeaguers")
                .WithSqlParam("@unitId", unitId)
                .ExecuteStoredProcAsync((result) =>
                {
                    source = result.ReadNextListOrEmpty<LeaguerModel>().ToList();

                    // Id is LeaguerId and Value is AttachmentId
                    var avatars = result.ReadNextListOrEmpty<SingleFieldModel<int>>().ToList();

                    source.ForEach(leaguer =>
                    {
                        var avatar = avatars.FirstOrDefault(_ => _.Id == leaguer.Id);
                        leaguer.AvatarId = avatar?.Value;
                    });
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

                    if (source.Reference.StatusId != AppLeaguerStatus.Official.ToInt()) return;

                    var officialDocuments = result.ReadNextListOrEmpty<AppliedDocumentModel>().ToList();
                    var officialDocumentAttachments = result.ReadNextListOrEmpty<AttachmentModel>().ToList();
                    if (!officialDocuments.Any()) return;
                    foreach (var officialDocument in officialDocuments)
                    {
                        var attachments = officialDocumentAttachments
                            .Where(_ => _.ReferenceId == officialDocument.Id).ToList();
                        source.Reference.OfficialDocuments.Add(new ReferenceWithAttachmentModel<AppliedDocumentModel>{
                            Reference = officialDocument,
                            Attachments = attachments,
                            TotalAttachments = attachments.Count
                        });
                    }
                });

            return source;
        }

        public static async Task<int> GetCurrentAvatarId(this IRepository<LeaguerAttachment> repository, int leaguerId)
        {
            var avatar = await repository.Entities.FirstOrDefaultAsync(_ => _.LeaguerId == leaguerId && _.IsAvatar);
            return avatar?.Id ?? 0;
        }

        public static async Task<List<LeaguerAttachment>> GetCurrentAttachments(this IRepository<LeaguerAttachment> repository, int leaguerId)
        {
            return await repository.Entities.Where(_ => _.LeaguerId == leaguerId).ToListAsync();
        }

        public static async Task<List<AppliedDocument>> GetMores(this IRepository<AppliedDocument> repository, IEnumerable<int> ids)
        {
            return await repository.Entities.Where(_ => ids.Contains(_.Id)).ToListAsync();
        }

        public static async Task<List<AppliedDocument>> GetAppliedDocuments(this IRepository<AppliedDocument> repository, int leaguerId)
        {
            var db = (LeaguerManagementContext)repository.DbContext;

            return await (from a in db.AppliedDocuments
                join cod in db.ChangeOfficialDocuments on a.OfficialDocumentId equals cod.Id
                where a.LeaguerId == leaguerId && cod.ChangeOfficialDocumentTypeId != 3
                select a).ToListAsync();
        }

        public static async Task<List<AppliedDocumentAttachment>> GetAppliedOfficialAttachments(this IRepository<AppliedDocumentAttachment> repository, int leaguerId)
        {
            var db = (LeaguerManagementContext)repository.DbContext;

            return await (from a in db.AppliedDocuments
                          join aa in db.AppliedDocumentAttachments on a.Id equals aa.AppliedDocumentId
                          where a.LeaguerId == leaguerId
                          select aa).ToListAsync();
        }

        public static async Task<IList<ReferenceWithAttachmentModel<AppliedDocumentModel>>> GetAppliedOfficialDocuments(this IRepository<AppliedDocument> repository, int leaguerId)
        {
            var source = new List<ReferenceWithAttachmentModel<AppliedDocumentModel>>();
            await repository.LoadStoredProc("spGetOfficialDocuments")
                .WithSqlParam("@LeaguerId", leaguerId)
                .ExecuteStoredProcAsync((result) =>
                {
                    var appliedDocuments = result.ReadNextListOrEmpty<AppliedDocumentModel>().ToList();

                    if (!appliedDocuments.Any()) return;

                    var attachments = result.ReadNextListOrEmpty<AttachmentModel>().ToList();

                    source.AddRange(from appliedDocument in appliedDocuments
                                    let modelAttachments = attachments.Where(_ => _.ReferenceId == appliedDocument.Id).ToList()
                                    select new ReferenceWithAttachmentModel<AppliedDocumentModel>
                                    {
                                        Reference = appliedDocument,
                                        Attachments = modelAttachments,
                                        TotalAttachments = modelAttachments.Count
                                    });
                });

            return source;
        }

        public static async Task<IList<LeaguerBookModel>> ExportAllLeaguerToExcel(this IRepository<Leaguer> repository, int? unitId)
        {
            var source = new List<LeaguerBookModel>();
            await repository.LoadStoredProc("spExportLeaguerToExcel")
                .WithSqlParam("@unitId", unitId)
                .ExecuteStoredProcAsync((result) =>
                {
                    var units = result.ReadNextListOrEmpty<UnitModel>().ToList();

                    var leaguers = result.ReadNextListOrEmpty<LeaguerModel>().ToList();

                    units.ForEach(unit =>
                    {
                        var unitLeaguers = leaguers.Where(_ => _.UnitId == unit.Id).Select(l => new LeaguerExcelModel
                        {
                            Name = l.Name,
                            BornYear = l.BornYear,
                            Gender = l.Gender ? "Name" : "Nữ",
                            Religion = l.Religion,
                            Folk = l.Folk,
                            HomeTown = l.HomeTown,
                            EducationalLevel = l.EducationalLevel,
                            PoliticalTheoryLevel = l.PoliticalTheoryLevel,
                            ForeignLanguageLevel = l.ForeignLanguageLevel,
                            SpecializeMajor = l.SpecializeMajor,
                            BeforeEnteringCareer = l.BeforeEnteringCareer,
                            CurrentCareer = l.CurrentCareer,
                            Position = l.Position,
                            UnitName = unit.Name,
                            PreliminaryApplyDate = l.PreliminaryApplyDate,
                            OfficialApplyDate = l.OfficialApplyDate,
                            CardNumber = l.CardNumber,
                            BackgroundNumber = l.BackgroundNumber,
                            BadgeNumber = l.BadgeNumber,
                            MoveOutDated = l.MoveOutDated,
                            OfficeComing = l.OfficeComing,
                            MoveInDated = l.MoveInDated,
                            AtOffice = l.AtOffice,
                            GetOutDate = l.GetOutDate,
                            FormOut = l.FormOut,
                            Phone = l.Phone,
                            Notes = l.Notes,
                        });

                        var book = new LeaguerBookModel
                        {
                            Unit = new UnitExcelModel
                            {
                                IdentifyNumber = unit.IdentifyNumber,
                                Name = unit.Name
                            },
                            Leaguers = unitLeaguers.ToList()
                        };

                        source.Add(book);
                    });
                });

            return source;
        }
    }
}
