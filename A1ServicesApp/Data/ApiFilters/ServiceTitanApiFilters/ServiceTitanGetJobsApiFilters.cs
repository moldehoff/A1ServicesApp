using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Constants.ServiceTitanApiFilters
{
    public class FilterCompletedAfter : IApiFilter
    {
        public const string FilterName = "filter.completedAfter";
        public DateTime FilterValue { get; set; }

        public string BuildFilterString()
        {
            return FilterName + "=" + FilterValue;
        }
    }

    public class FilterCompletedBefore : IApiFilter
    {
        public const string FilterName = "filter.completedBefore";

        public DateTime FilterValue { get; set; }

        public string BuildFilterString()
        {
            return FilterName + "=" + FilterValue;
        }
    }

    public class FilterStartsAfter : IApiFilter
    {
        public const string FilterName = "filter.startsAfter";
        public DateTime FilterValue { get; set; }

        public string BuildFilterString()
        {
            return FilterName + "=" + FilterValue;
        }
    }

    public class FilterStartsBefore : IApiFilter
    {
        public const string FilterName = "filter.startsBefore";
        public DateTime FilterValue { get; set; }

        public string BuildFilterString()
        {
            return FilterName + "=" + FilterValue;
        }
    }
}
