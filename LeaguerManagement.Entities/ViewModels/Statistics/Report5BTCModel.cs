using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels
{
    public class Report5BTCModel
    {
        public IList<UnitModel> Units { get; set; }
        public IList<Leaguer5BtcModel> Leaguers { get; set; }

        public Report5BTCModel()
        {
            Units = new List<UnitModel>();
            Leaguers = new List<Leaguer5BtcModel>();
        }
    }

    public class Leaguer5BtcModel
    {
        public string Name { get; set; }
        public int RatingId { get; set; }
        public int UnitId { get; set; }
    }
}
