using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.Jobs.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Jobs.Queries
{
    public class GetJobsFromServiceTitanQueryHandler : IRequestHandler<GetJobsFromServiceTitanQuery, ServiceTitanJobsListDto>
    {
        public Task<ServiceTitanJobsListDto> Handle(GetJobsFromServiceTitanQuery request, CancellationToken cancellationToken)
        {
            var result = new ServiceTitanJobsListDto();


            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            bool hasMore = true;
            int page = 1;

            string baseRequestUrl = GetJobsFromServiceTitanQuery.BaseApiUrl + "?" + "serviceTitanApiKey=" + request.ApiKey;
            string apiFilters = "";

            foreach (var filter in request.ApiFilters)
            {
                apiFilters += "&" + filter.BuildFilterString();

            }

            while (hasMore)
            {
                
                var pageFilter = "&filter.page=" + page;
                var requestUrl = baseRequestUrl + apiFilters + pageFilter;

                var stringTask = client.GetStringAsync(requestUrl).Result;
                var apiResults = JsonConvert.DeserializeObject<ServiceTitanEntityCollectionResult<ServiceTitanJobModel>>(stringTask);

                result.ApiResults = apiResults;

                hasMore = apiResults.HasMore;
                page++;
            }

            return Task.FromResult<ServiceTitanJobsListDto>(result);
        }     
    }
}
