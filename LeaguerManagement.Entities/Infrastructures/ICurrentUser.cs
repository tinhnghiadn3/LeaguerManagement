namespace LeaguerManagement.Entities.Infrastructures
{
    public interface ICurrentUser
    {
        int? UserId { get; set; }
        int? RoleId { get; set; }
        int? UnitId { get; set; }
    }
}
