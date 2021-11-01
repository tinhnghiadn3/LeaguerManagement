using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class Unit
    {
        public Unit()
        {
            LeaguerLivingUnits = new HashSet<Leaguer>();
            LeaguerUnits = new HashSet<Leaguer>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentifyNumber { get; set; }

        public virtual ICollection<Leaguer> LeaguerLivingUnits { get; set; }
        public virtual ICollection<Leaguer> LeaguerUnits { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
