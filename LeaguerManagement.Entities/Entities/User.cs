using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class User
    {
        public User()
        {
            File = new HashSet<File>();
            UserRole = new HashSet<UserRole>();
            UserToken = new HashSet<UserToken>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsActivated { get; set; }
        public string JobPosition { get; set; }

        public virtual ICollection<File> File { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<UserToken> UserToken { get; set; }
    }
}
