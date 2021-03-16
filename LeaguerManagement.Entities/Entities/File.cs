using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class File
    {
        public File()
        {
            AppliedDocument = new HashSet<AppliedDocument>();
        }

        public int Id { get; set; }
        public int FileTypeId { get; set; }
        public int FirstApplicantId { get; set; }
        public int? SecondApplicantId { get; set; }
        public int DetailId { get; set; }
        public int? CreateByUserId { get; set; }
        public bool? IsActivated { get; set; }
        public int? UpdateByUserId { get; set; }

        public virtual User CreateByUser { get; set; }
        public virtual FileDetail Detail { get; set; }
        public virtual FileType FileType { get; set; }
        public virtual Applicant FirstApplicant { get; set; }
        public virtual Applicant SecondApplicant { get; set; }
        public virtual ICollection<AppliedDocument> AppliedDocument { get; set; }
    }
}
