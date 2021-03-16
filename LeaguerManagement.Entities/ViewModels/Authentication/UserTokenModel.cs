using System;

namespace LeaguerManagement.Entities.ViewModels.Authentication
{
	public class UserTokenModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string ImageToken { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsRevoked { get; set; }
    }
}
