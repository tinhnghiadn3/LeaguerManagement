using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class Status
    {
        public Status()
        {
            Leaguers = new HashSet<Leaguer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Leaguer> Leaguers { get; set; }
    }
}
