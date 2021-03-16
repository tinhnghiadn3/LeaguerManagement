using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class PointResult
    {
        public PointResult()
        {
            FileDetail = new HashSet<FileDetail>();
        }

        public int Id { get; set; }
        public bool IsRecorded { get; set; }

        public virtual ICollection<FileDetail> FileDetail { get; set; }
    }
}
