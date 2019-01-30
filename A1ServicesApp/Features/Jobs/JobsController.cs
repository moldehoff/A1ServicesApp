using A1ServicesApp.Features.Jobs.Models;
using A1ServicesApp.Features.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}