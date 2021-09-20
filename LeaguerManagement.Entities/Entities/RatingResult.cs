using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class RatingResult
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public int? RatingId { get; set; }
        public int? LeaguerId { get; set; }

        public virtual Leaguer Leaguer { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
