using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class Leaguer
    {
        public Leaguer()
        {
            AppliedDocuments = new HashSet<AppliedDocument>();
            LeaguerAttachments = new HashSet<LeaguerAttachment>();
            RatingResults = new HashSet<RatingResult>();
        }

        public int Id { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }
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

        public virtual Status Status { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<AppliedDocument> AppliedDocuments { get; set; }
        public virtual ICollection<LeaguerAttachment> LeaguerAttachments { get; set; }
        public virtual ICollection<RatingResult> RatingResults { get; set; }
    }
}
