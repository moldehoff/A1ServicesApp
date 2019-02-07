using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using A1ServicesApp.Features.JobMaterials.Queries;
using A1ServicesApp.Features.Jobs.Models;
using A1ServicesApp.Features.Jobs.Queries;
using A1ServicesApp.Features.JobServiceMaterialLinks.Commands;
using A1ServicesApp.Features.JobServiceMaterialLinks.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks
{
    [Route("api/[controller]")]
    public class JobServiceMaterialLinksController : Controller
    {
        private IMediator _mediator;

        public JobServiceMaterialLinksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllJobMaterialLinks()
        {
            var result = _mediator.Send(new GetAllJobMaterialLinksQuery()).Result;


            return Ok(result);
        }

        [HttpGet("{linkId}")]
        public IActionResult GetJobMaterialLinkById(int linkId)
        {
            var result = _mediator.Send(new GetJobServiceMaterialLinkByIdQuery() { Id = linkId }).Result;


            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateNewJobServiceMaterialLink([FromBody] NewJobServiceMaterialLinkDto model)
        {
            var result = _mediator.Send(new CreateNewJobServiceMaterialLinkCommand(model)).Result;

            return Created(result.Id.ToString(), result);
        }



        [HttpGet("findmissinglinks")]
        public IActionResult GetJobsWithMissingJobMaterials()
        {
            DateTime dateToday = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);

            var queryStringModel = new GetJobsQueryStringModel()
            {
                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",
                CompletedBefore = new FilterCompletedBefore() { FilterValue = dateToday.AddDays(-10)},
                CompletedAfter = new FilterCompletedAfter() { FilterValue = dateToday.AddDays(-15)}
            };
   
            var getJobsFromST = _mediator.Send(new GetJobsFromServiceTitanQuery(queryStringModel)).Result;

            var result = _mediator.Send(new FindJobsWithMismatchedJobMaterialsQuery() {Jobs = getJobsFromST.ApiResults }).Result;

            return Ok(result);
        }
    }
}
