using DevExtreme.AspNet.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class ColumnFilter
    {
        public string Field { get; set; }
        public string Operation { get; set; }
        public object Value { get; set; }
    }

    public class SearchParamsModel
    {
        [Range(0, int.MaxValue)]
        public int Skip { get; set; }
        [Range(0, 100)]
        public int Take { get; set; }
        public List<ColumnFilter> Filter { get; set; }
        public string SortBy { get; set; }
        public bool SortDesc { get; set; }
    }

    public class LoadOptionsModel
    {
        public DataSourceLoadOptionsBase LoadOptions { get; set; }

        public string TextFilter { get; set; }

        public int TypeFilter { get; set; }

        public int? ReferenceId { get; set; }
    }
}
