using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Ward
    {
        public Ward()
        {
            Apartment = new HashSet<Apartment>();
            Applicant = new HashSet<Applicant>();
            Certificate = new HashSet<Certificate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Apartment> Apartment { get; set; }
        public virtual ICollection<Applicant> Applicant { get; set; }
        public virtual ICollection<Certificate> Certificate { get; set; }
    }
}
