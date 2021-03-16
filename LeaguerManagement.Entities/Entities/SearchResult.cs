using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class SearchResult
    {
        public SearchResult()
        {
            Certificate = new HashSet<Certificate>();
            FileDetail = new HashSet<FileDetail>();
            SearchResultAttachment = new HashSet<SearchResultAttachment>();
        }

        public int Id { get; set; }
        public bool IsRecorded { get; set; }

        public virtual ICollection<Certificate> Certificate { get; set; }
        public virtual ICollection<FileDetail> FileDetail { get; set; }
        public virtual ICollection<SearchResultAttachment> SearchResultAttachment { get; set; }
    }
}
