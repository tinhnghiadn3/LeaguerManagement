using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class AccessOfRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccessControlId { get; set; }
        public bool IsActivated { get; set; }
    }
}
