using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class CopyResult
    {
        public CopyResult()
        {
            CopiedDocument = new HashSet<CopiedDocument>();
            FileDetail = new HashSet<FileDetail>();
        }

        public int Id { get; set; }
        public bool IsRecorded { get; set; }

        public virtual ICollection<CopiedDocument> CopiedDocument { get; set; }
        public virtual ICollection<FileDetail> FileDetail { get; set; }
    }
}
