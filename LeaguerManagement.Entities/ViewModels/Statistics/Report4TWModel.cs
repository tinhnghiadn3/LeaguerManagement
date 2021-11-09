
using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels
{
    public class Report4TWModel
    {
        public IList<Data4TWModel> Folks { get; set; }
        public IList<Data4TWModel> FemaleFolks { get; set; }
        public IList<Data4TWModel> Religions { get; set; }
        public double Total { get; set; }
    }

    public class Data4TWModel
    {
        public string Name { get; set; }
        public double Total { get; set; }
    }
}
