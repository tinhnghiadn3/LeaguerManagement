using System;

namespace LeaguerManagement.Entities.Entities
{
    public partial class SearchResultAttachment
    {
        public int Id { get; set; }
        public int? ResultId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileUrl { get; set; }
        public long? FileSize { get; set; }
        public string FileExtension { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }

        public virtual SearchResult Result { get; set; }
    }
}
