using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Role
    {
        public Role()
        {
            AccessOfRole = new HashSet<AccessOfRole>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccessOfRole> AccessOfRole { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
