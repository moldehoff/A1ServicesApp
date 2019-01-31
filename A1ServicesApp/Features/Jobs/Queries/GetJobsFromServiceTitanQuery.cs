using A1ServicesApp.Data.Constants;
using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using A1ServicesApp.Features.Jobs.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Jobs.Queries
{
    public class GetJobsFromServiceTitanQuery : IRequest<ServiceTitanJobsListDto>
    {
        public GetJobsFromServiceTitanQuery(GetJobsQueryStringModel model)
        {
            ApiKey = model.ApiKey;
            ApiFilters = new List<IApiFilter>();

            ApiFilters.Add(new FilterCompletedAfter()
            {
                FilterValue = model.CompletedAfter.FilterValue
            });
            ApiFilters.Add(new FilterCompletedBefore()
            {
                FilterValue = model.CompletedBefore.FilterValue
            });
        }


        public const string BaseApiUrl = "HTTPS://api.servicetitan.com/v1/jobs";
        public string ApiKey { get; set; }
        public ICollection<IApiFilter> ApiFilters { get; set; } = new List<IApiFilter>();
        
        
    }
}
