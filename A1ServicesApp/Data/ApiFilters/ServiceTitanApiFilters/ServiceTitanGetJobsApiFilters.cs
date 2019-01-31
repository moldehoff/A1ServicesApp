using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Constants.ServiceTitanApiFilters
{
    public class FilterCompletedAfter : IApiFilter
    {
        public string FilterName { get; set; } = "filter.completedAfter";
        public DateTime FilterValue { get; set; }

        public string BuildFilterString()
        {
            return FilterName + "=" + FilterValue;
        }
    }

    public class FilterCompletedBefore : IApiFilter
    {
        public string FilterName { get; set; } = "filter.completedBefore";

        public DateTime FilterValue { get; set; }

        public string BuildFilterString()
        {
            return FilterName + "=" + FilterValue;
        }
    }
}
