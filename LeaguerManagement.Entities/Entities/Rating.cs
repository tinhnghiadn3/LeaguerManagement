using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class Rating
    {
        public Rating()
        {
            RatingResults = new HashSet<RatingResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RatingResult> RatingResults { get; set; }
    }
}
