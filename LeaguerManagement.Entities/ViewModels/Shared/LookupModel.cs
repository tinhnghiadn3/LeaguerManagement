using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels
{
    public class LookupModel
    {
        public IList<DropDownModel<int>> Roles { get; set; }
        public IList<DropDownModel<int>> Units { get; set; }
        public IList<DropDownModel<int>> Statuses { get; set; }
        public IList<DropDownModel<int>> ChangeOfficialDocumentTypes { get; set; }
        public IList<ChangeOfficialDocumentModel> ChangeOfficialDocuments { get; set; }
        public IList<DropDownModel<int>> Ratings { get; set; }

        public LookupModel()
        {
            Roles = new List<DropDownModel<int>>();
            Units = new List<DropDownModel<int>>();
            Statuses = new List<DropDownModel<int>>();
            ChangeOfficialDocumentTypes = new List<DropDownModel<int>>();
            ChangeOfficialDocuments = new List<ChangeOfficialDocumentModel>();
            Ratings = new List<DropDownModel<int>>();
        }
    }
}
