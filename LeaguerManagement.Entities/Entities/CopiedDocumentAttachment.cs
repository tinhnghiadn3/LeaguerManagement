using System;

namespace LeaguerManagement.Entities.Entities
{
    public partial class CopiedDocumentAttachment
    {
        public int Id { get; set; }
        public int? CopiedDocumentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileUrl { get; set; }
        public long? FileSize { get; set; }
        public string FileExtension { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }

        public virtual CopiedDocument CopiedDocument { get; set; }
    }
}
