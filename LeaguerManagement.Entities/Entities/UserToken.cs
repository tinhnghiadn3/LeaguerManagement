using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class UserToken
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Token { get; set; }
        public string ImageToken { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsRevoked { get; set; }
    }
}
