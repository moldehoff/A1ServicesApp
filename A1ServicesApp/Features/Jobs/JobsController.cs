using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using A1ServicesApp.Features.Jobs.Models;
using A1ServicesApp.Features.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Jobs
{
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        private IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetJobsFromCRM([FromBody] GetJobsQueryStringModel queryString)
        {
            var requestObject = new GetJobsFromServiceTitanQuery(queryString);
            var result = _mediator.Send(requestObject).Result;


            return Ok(result.ApiResults);
        }

        [HttpGet("groups")]
        public IActionResult GetJobsFromCRMGrouped([FromBody] GetJobsQueryStringModel queryString)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);

            var queryStringModel = new GetJobsQueryStringModel()
            {
                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",
                CompletedBefore = new FilterCompletedBefore() { FilterValue = todaysDate.AddDays(0) },
                CompletedAfter = new FilterCompletedAfter() { FilterValue = todaysDate.AddDays(-5) }
            };

            var requestObject = new GetJobsFromServiceTitanQuery(queryStringModel);
            var result = _mediator.Send(requestObject).Result;
            stopWatch.Stop();
            var groupedByCreator = result.ApiResults.GroupBy(j => j.CreatedBy.Name).OrderBy(c=>c.Key).ToList();

            var groupedByHour = result.ApiResults.GroupBy(j => (DateTime.Parse(j.CreatedOn)).Hour).OrderBy(g=>g.Key).ToList();

            return Ok(result.ApiResults);

        }
    }
}