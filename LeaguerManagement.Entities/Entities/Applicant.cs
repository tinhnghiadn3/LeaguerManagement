using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Applicant
    {
        public Applicant()
        {
            FileFirstApplicant = new HashSet<File>();
            FileSecondApplicant = new HashSet<File>();
        }

        public int Id { get; set; }
        public int? ApplicantTypeId { get; set; }
        public string Name { get; set; }
        public string YearOfBirth { get; set; }
        public int IdentifyCode { get; set; }
        public DateTime DatedIdentifyCode { get; set; }
        public int? CityId { get; set; }
        public string PhoneNumber { get; set; }
        public int? WardId { get; set; }
        public int? StreetId { get; set; }
        public int? ApartmentId { get; set; }
        public string HouseCode { get; set; }
        public string Email { get; set; }
        public string OrganizationName { get; set; }
        public string Zone { get; set; }
        public int? IdentifyNumberTypeId { get; set; }
        public int? PronounsId { get; set; }
        public string HouseName { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual ApplicantType ApplicantType { get; set; }
        public virtual City City { get; set; }
        public virtual Pronouns Pronouns { get; set; }
        public virtual Street Street { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<File> FileFirstApplicant { get; set; }
        public virtual ICollection<File> FileSecondApplicant { get; set; }
    }
}
