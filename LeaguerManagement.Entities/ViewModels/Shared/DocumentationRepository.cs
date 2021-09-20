using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public static class DocumentationRepository
    {

        public static async Task<bool> IsDuplicated(this IRepository<Documentation> repository, int id, string name)
        {
            return await repository.Entities.AnyAsync(_ => _.Id != id && _.Name.ToLower() == name.ToLower());
        }

        public static async Task<List<DocumentationAttachment>> GetCurrentAttachments(this IRepository<DocumentationAttachment> repository, int documentationId)
        {
            return await repository.Entities.Where(_ => _.DocumentationId == documentationId).ToListAsync();
        }
    }
}
