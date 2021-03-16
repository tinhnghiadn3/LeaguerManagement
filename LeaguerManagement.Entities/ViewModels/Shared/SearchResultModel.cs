using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class SearchResultModel<T>
    {
        public IList<T> DataSource { get; set; }
        public float Total { get; set; }
    }
}
