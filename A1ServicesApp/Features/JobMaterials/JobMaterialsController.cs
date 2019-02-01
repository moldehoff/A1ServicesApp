using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using A1ServicesApp.Features.JobMaterials.Queries;
using A1ServicesApp.Features.Jobs.Models;
using A1ServicesApp.Features.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials
{
    [Route("api/[controller]")]
    public class JobMaterialsController : Controller
    {
        private IMediator _mediator;

        public JobMaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetJobsWithMissingJobMaterials()
        {
            var queryStringModel = new GetJobsQueryStringModel()
            {
                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",
                CompletedBefore = new FilterCompletedBefore() { FilterValue = DateTime.Today.AddDays(0).ToUniversalTime()},
                CompletedAfter = new FilterCompletedAfter() { FilterValue = DateTime.Today.AddDays(-1).ToUniversalTime()}
            };
   
            var getJobsFromST = _mediator.Send(new GetJobsFromServiceTitanQuery(queryStringModel)).Result;

            var result = _mediator.Send(new FindJobsWithMismatchedJobMaterialsQuery() {Jobs = getJobsFromST.ApiResults }).Result;

            return Ok(result.Jobs);
        }
    }
}
