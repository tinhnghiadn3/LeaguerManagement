namespace LeaguerManagement.Entities.Entities
{
    public partial class AccessOfRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccessControlId { get; set; }
        public bool IsActivated { get; set; }

        public virtual AccessControl AccessControl { get; set; }
        public virtual Role Role { get; set; }
    }
}
