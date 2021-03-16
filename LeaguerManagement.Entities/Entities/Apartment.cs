using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Apartment
    {
        public Apartment()
        {
            Applicant = new HashSet<Applicant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? WardId { get; set; }

        public virtual Ward Ward { get; set; }
        public virtual ICollection<Applicant> Applicant { get; set; }
    }
}
