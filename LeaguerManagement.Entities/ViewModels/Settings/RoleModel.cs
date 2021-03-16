using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels.Settings
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int> AccessControlIds { get; set; }

        public RoleModel()
        {
            AccessControlIds = new List<int>();
        }
    }
}
