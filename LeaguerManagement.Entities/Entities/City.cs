using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class City
    {
        public City()
        {
            Applicant = new HashSet<Applicant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Applicant> Applicant { get; set; }
    }
}
