namespace LeaguerManagement.Entities.ViewModels.Authentication
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public double TimezoneOffset { get; set; }
    }
}
