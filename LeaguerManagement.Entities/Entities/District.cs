using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class District
    {
        public District()
        {
            AppliedDocument = new HashSet<AppliedDocument>();
            Ward = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppliedDocument> AppliedDocument { get; set; }
        public virtual ICollection<Ward> Ward { get; set; }
    }
}
