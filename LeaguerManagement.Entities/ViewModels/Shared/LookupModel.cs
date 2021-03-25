using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class LookupModel
    {
        public IList<DropDownModel<int>> Roles { get; set; }
        public IList<DropDownModel<int>> Units { get; set; }
        public IList<DropDownModel<int>> Statuses { get; set; }

        public LookupModel()
        {
            Roles = new List<DropDownModel<int>>();
            Units = new List<DropDownModel<int>>();
            Statuses = new List<DropDownModel<int>>();
        }
    }
}
