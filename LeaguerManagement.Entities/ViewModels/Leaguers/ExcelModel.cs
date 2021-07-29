using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels
{
    public class LeaguerExcelModel {
        public string Name { get; set; }
        public int BornYear { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Folk { get; set; }
        public string HomeTown { get; set; }
        public string EducationalLevel { get; set; }
        public string PoliticalTheoryLevel { get; set; }
        public string ForeignLanguageLevel { get; set; }
        public string SpecializeMajor { get; set; }
        public string BeforeEnteringCareer { get; set; }
        public string CurrentCareer { get; set; }
        public string Position { get; set; }
        public string UnitName { get; set; }
        public DateTime? PreliminaryApplyDate { get; set; }
        public DateTime? OfficialApplyDate { get; set; }
        public string CardNumber { get; set; }
        public string BackgroundNumber { get; set; }
        public string BadgeNumber { get; set; }
        public DateTime? MoveOutDated { get; set; }
        public string OfficeComing { get; set; }
        public DateTime? MoveInDated { get; set; }
        public string AtOffice { get; set; }
        public DateTime? DeadDate { get; set; }
        public string DeathReason { get; set; }
        public DateTime? GetOutDate { get; set; }
        public string FormOut { get; set; }
        public int? Phone { get; set; }
        public string Notes { get; set; }
    }

    public class UnitExcelModel
    {
        public string IdentifyNumber { get; set; }
        public string Name { get; set; }
    }

    public class LeaguerBookModel
    {
        public UnitExcelModel Unit { get; set; }
        public List<LeaguerExcelModel> Leaguers { get; set; }
    }
}
