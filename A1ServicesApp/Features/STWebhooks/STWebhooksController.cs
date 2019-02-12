using A1ServicesApp.Data.Entities.ServiceTitan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.STWebhooks
{
    [Route("api/[controller]")]
    public class STWebhooksController : Controller
    {
        private IMediator _mediator;

        public STWebhooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("jobcompleted")]
        public IActionResult ReceiveCompletedServiceTitanJob([FromBody]ServiceTitanJobModel job)
        {




            return Ok();
        }


        
    }
}
