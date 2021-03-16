using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class AccessControl
    {
        public AccessControl()
        {
            AccessOfRole = new HashSet<AccessOfRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccessOfRole> AccessOfRole { get; set; }
    }
}
