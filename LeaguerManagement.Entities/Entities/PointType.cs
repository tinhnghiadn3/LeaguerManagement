using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class PointType
    {
        public PointType()
        {
            AppliedDocument = new HashSet<AppliedDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppliedDocument> AppliedDocument { get; set; }
    }
}
