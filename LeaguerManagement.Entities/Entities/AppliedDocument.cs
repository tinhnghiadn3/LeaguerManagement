using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class AppliedDocument
    {
        public AppliedDocument()
        {
            AppliedDocumentAttachment = new HashSet<AppliedDocumentAttachment>();
        }

        public int Id { get; set; }
        public int? FileId { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public int? DistrictId { get; set; }
        public string Unit { get; set; }
        public string Purpose { get; set; }
        public int? PointTypeId { get; set; }
        public int? PointValue { get; set; }
        public bool? IsAttachment { get; set; }

        public virtual District District { get; set; }
        public virtual File File { get; set; }
        public virtual PointType PointType { get; set; }
        public virtual ICollection<AppliedDocumentAttachment> AppliedDocumentAttachment { get; set; }
    }
}
