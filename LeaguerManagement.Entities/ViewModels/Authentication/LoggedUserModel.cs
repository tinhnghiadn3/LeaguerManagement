using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels
{
    public class LoggedUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int? UnitId { get; set; }
        public IList<int> AccessControlIds { get; set; }

        public LoggedUserModel()
        {
            AccessControlIds = new List<int>();
        }
    }
}
