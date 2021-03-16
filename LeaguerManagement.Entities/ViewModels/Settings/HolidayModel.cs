using System;

namespace LeaguerManagement.Entities.ViewModels.Settings
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsSunday { get; set; }
        public bool Is11 { get; set; }
        public bool Is304 { get; set; }
        public bool Is15 { get; set; }
        public bool Is29 { get; set; }
        public bool IsSettings { get; set; }
        public int Year { get; set; }
    }
}
