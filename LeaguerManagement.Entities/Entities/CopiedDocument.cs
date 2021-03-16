using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class CopiedDocument
    {
        public CopiedDocument()
        {
            CopiedDocumentAttachment = new HashSet<CopiedDocumentAttachment>();
        }

        public int Id { get; set; }
        public int CopyResultId { get; set; }
        public int CopyTypeId { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public int DocumentTypeId { get; set; }
        public int Amount { get; set; }

        public virtual CopyResult CopyResult { get; set; }
        public virtual CopyType CopyType { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<CopiedDocumentAttachment> CopiedDocumentAttachment { get; set; }
    }
}
