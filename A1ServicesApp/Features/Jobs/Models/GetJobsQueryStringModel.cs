using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Jobs.Models
{
    public class GetJobsQueryStringModel
    {
        public FilterCompletedBefore CompletedBefore { get; set; }
        public FilterCompletedAfter CompletedAfter { get; set; }
        public string ApiKey { get; set; }

    }
}
