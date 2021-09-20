using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories.Extensions;

namespace LeaguerManagement.Repositories
{
    public static class DocumentationRepository
    {
        public static async Task<IList<ReferenceWithAttachmentModel<BaseSettingModel>>> GetDocumentations(this IRepository<Documentation> repository)
        {
            var source = new List<ReferenceWithAttachmentModel<BaseSettingModel>>();
            await repository.LoadStoredProc("spGetDocumentations")
                .ExecuteStoredProcAsync((result) =>
                {
                    var documentations = result.ReadNextListOrEmpty<BaseSettingModel>().ToList();

                    if (!documentations.Any()) return;

                    var attachments = result.ReadNextListOrEmpty<AttachmentModel>().ToList();

                    source.AddRange(from documentation in documentations
                                    let modelAttachments = attachments.Where(_ => _.ReferenceId == documentation.Id).ToList()
                        select new ReferenceWithAttachmentModel<BaseSettingModel>
                        {
                            Reference = documentation,
                            Attachments = modelAttachments,
                            TotalAttachments = modelAttachments.Count
                        });
                });

            return source;
        }
    }
}
