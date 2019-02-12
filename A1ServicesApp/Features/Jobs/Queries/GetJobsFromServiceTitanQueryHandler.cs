﻿using A1ServicesApp.Data.Entities.ServiceTitan;
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
using A1ServicesApp.Data.ExtensionMethods;

namespace A1ServicesApp.Features.Jobs.Queries
{
    public class GetJobsFromServiceTitanQueryHandler : IRequestHandler<GetJobsFromServiceTitanQuery, ServiceTitanJobsListDto>
    {
        public Task<ServiceTitanJobsListDto> Handle(GetJobsFromServiceTitanQuery request, CancellationToken cancellationToken)
        {
            var result = new ServiceTitanJobsListDto();

            var jobs = new List<ServiceTitanJobModel>();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            bool hasMore = true;
            int page = 1;
            string apiKey = "0a947558-f14f-4823-b948-e52533c45684";
            string baseRequestUrl = GetJobsFromServiceTitanQuery.BaseApiUrl + "?" + "serviceTitanApiKey=" + apiKey;
            string apiFilters = "";

            foreach (var filter in request.ApiFilters)
            {
                apiFilters += "&" + filter.BuildFilterString();

            }

            while (hasMore)
            {
                
                var pageFilter = "&filter.page=" + page + "&filter.pageSize=250";
                var requestUrl = baseRequestUrl + apiFilters + pageFilter;

                var stringTask = client.GetStringAsync(requestUrl).Result;
                var apiResults = JsonConvert.DeserializeObject<ServiceTitanEntityCollectionResult<ServiceTitanJobModel>>(stringTask);

                jobs.AddRange(apiResults.Data);

                

                hasMore = apiResults.HasMore;
                page++;
            }
            result.ApiResults = jobs;

            return Task.FromResult<ServiceTitanJobsListDto>(result);
        }     
    }
}
