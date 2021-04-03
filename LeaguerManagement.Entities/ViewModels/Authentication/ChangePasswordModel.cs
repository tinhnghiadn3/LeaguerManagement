namespace LeaguerManagement.Entities.ViewModels
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPass { get; set; }
    }
}
