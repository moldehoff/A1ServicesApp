using A1ServicesApp.Features.JobServices.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServices
{
    [Route("api/[controller]")]
    public class JobServicesController : Controller
    {
        private IMediator _mediator;

        public JobServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult GetAllJobServices()
        {
            var result = _mediator.Send(new GetAllJobServicesQuery()).Result;


            return Ok(result.Take(500).ToList());
        }

        [HttpGet("{serviceId}")]
        public IActionResult GetJobServiceById(int serviceId)
        {
            var result = _mediator.Send(new GetJobServiceByIdQuery() { ServiceId = serviceId }).Result;

            return Ok(result);
        }
    }
}
