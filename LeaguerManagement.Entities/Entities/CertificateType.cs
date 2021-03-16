using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class CertificateType
    {
        public CertificateType()
        {
            Certificate = new HashSet<Certificate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Certificate> Certificate { get; set; }
    }
}
