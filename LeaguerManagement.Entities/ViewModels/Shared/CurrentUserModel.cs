using LeaguerManagement.Entities.Infrastructures;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class CurrentUserModel : ICurrentUser
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}
