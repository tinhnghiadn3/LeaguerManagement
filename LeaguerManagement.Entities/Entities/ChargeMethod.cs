using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class ChargeMethod
    {
        public ChargeMethod()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
