using LeaguerManagement.Entities.Infrastructures;

namespace LeaguerManagement.Entities.ViewModels
{
    public class CurrentUserModel : ICurrentUser
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? UnitId { get; set; }
    }
}
