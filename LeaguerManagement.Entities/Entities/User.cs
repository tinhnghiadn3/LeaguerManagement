using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class User
    {
        public User()
        {
            LeaguerAttachments = new HashSet<LeaguerAttachment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsActivated { get; set; }
        public string JobPosition { get; set; }
        public int? UnitId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual ICollection<LeaguerAttachment> LeaguerAttachments { get; set; }
    }
}
