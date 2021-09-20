using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels
{
    public class LeaguerModel
    {

        public LeaguerModel()
        {
            OfficialDocuments = new List<ReferenceWithAttachmentModel<AppliedDocumentModel>>();
        }
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }
        public int? AvatarId { get; set; }
        public int BornYear { get; set; }
        public bool Gender { get; set; }
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
        public int StatusId { get; set; }
        public bool IsActivated { get; set; }

        public IList<ReferenceWithAttachmentModel<AppliedDocumentModel>> OfficialDocuments { get; set; }
        public IList<RatingResultModel> RatingResults { get; set; }
    }
}
