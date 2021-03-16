using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Pronouns
    {
        public Pronouns()
        {
            Applicant = new HashSet<Applicant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Applicant> Applicant { get; set; }
    }
}
