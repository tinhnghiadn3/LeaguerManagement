using System.Collections.Generic;
using LeaguerManagement.Entities.ViewModels.Settings;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class LookupModel
    {
        public IList<DropDownModel<int>> Roles { get; set; }
        public IList<DropDownModel<int>> Districts { get; set; }
        public IList<WardModel> Wards { get; set; }
        public IList<DropDownModel<int>> ApplicantTypes { get; set; }
        public IList<DropDownModel<int>> DocumentTypes { get; set; }
        public IList<DropDownModel<int>> FileTypes { get; set; }
        public IList<DropDownModel<int>> Notifications { get; set; }
        public IList<DropDownModel<int>> Statuses { get; set; }
        public IList<DropDownModel<int>> Cities { get; set; }
        public IList<DropDownModel<int>> Streets { get; set; }
        public IList<DropDownModel<int>> Formalities { get; set; }
        public IList<ApartmentModel> Apartments { get; set; }
        public IList<DropDownModel<int>> IdentifyNumberTypes { get; set; }
        public IList<DropDownModel<int>> CopyTypes { get; set; }
        public IList<DropDownModel<int>> Pronouns { get; set; }
        public IList<DropDownModel<int>> ConfirmPurposes { get; set; }
        public IList<DropDownModel<int>> PointTypes { get; set; }

        public LookupModel()
        {
            Roles = new List<DropDownModel<int>>();
            Districts = new List<DropDownModel<int>>();
            Wards = new List<WardModel>();
            ApplicantTypes = new List<DropDownModel<int>>();
            DocumentTypes = new List<DropDownModel<int>>();
            FileTypes = new List<DropDownModel<int>>();
            Notifications = new List<DropDownModel<int>>();
            Statuses = new List<DropDownModel<int>>();
            Cities = new List<DropDownModel<int>>();
            Streets = new List<DropDownModel<int>>();
            Formalities = new List<DropDownModel<int>>();
            Apartments = new List<ApartmentModel>();
            IdentifyNumberTypes = new List<DropDownModel<int>>();
            CopyTypes = new List<DropDownModel<int>>();
            Pronouns = new List<DropDownModel<int>>();
            PointTypes = new List<DropDownModel<int>>();
        }
    }
}
