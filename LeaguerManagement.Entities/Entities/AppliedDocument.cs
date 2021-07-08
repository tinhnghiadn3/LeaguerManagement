using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class AppliedDocument
    {
        public AppliedDocument()
        {
            AppliedDocumentAttachments = new HashSet<AppliedDocumentAttachment>();
        }

        public int Id { get; set; }
        public int LeaguerId { get; set; }
        public string Name { get; set; }
        public int OfficialDocumentId { get; set; }

        public virtual Leaguer Leaguer { get; set; }
        public virtual ICollection<AppliedDocumentAttachment> AppliedDocumentAttachments { get; set; }
    }
}
