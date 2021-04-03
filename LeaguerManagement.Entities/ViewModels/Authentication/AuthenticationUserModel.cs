namespace LeaguerManagement.Entities.ViewModels
{
    public class AuthenticationUserModel
    {
        public string AccessToken { get; set; }
        public string ImageToken { get; set; }
        public string RefreshToken { get; set; }
        public long? Exp { get; set; }
        public string Id { get; set; }

        public LoggedUserModel User { get; set; }
    }
}
