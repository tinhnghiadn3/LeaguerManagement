﻿namespace LeaguerManagement.Entities.ViewModels
{
    public class AccessOfRoleModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccessControlId { get; set; }
        public bool IsActivated { get; set; }
    }
}
