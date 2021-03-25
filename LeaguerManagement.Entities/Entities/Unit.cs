using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class Unit
    {
        public Unit()
        {
            Leaguers = new HashSet<Leaguer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentifyNumber { get; set; }

        public virtual ICollection<Leaguer> Leaguers { get; set; }
    }
}
