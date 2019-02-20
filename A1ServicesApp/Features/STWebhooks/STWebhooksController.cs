using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.Invoices.Commands;
using A1ServicesApp.Features.JobMaterials.Queries;
using A1ServicesApp.Features.Services.Airtable.Commands;
using AutoMapper;
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
        private IMapper _mapper;

        public STWebhooksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("jobcompleted")]
        public async Task<IActionResult> ReceiveCompletedServiceTitanJob([FromBody]ServiceTitanPostJobCompleted_ResultModel model)
        {
            var job = _mapper.Map<ServiceTitanJobModel>(model);

            var jobList = new List<ServiceTitanJobModel>();
            jobList.Add(job);
            var resultListFindQuery = await _mediator.Send(new FindJobsWithMismatchedJobMaterialsQuery() { Jobs = jobList });
            var resultInvoiceValidator = await _mediator.Send(new ValidateJobInvoiceCommand() { Job = job });

            foreach (var result in resultListFindQuery)
            {
                await _mediator.Send(new AddInvoiceExceptionRecordToAirtableCommand() { FlaggedJob = result });
            }

            foreach (var error in resultInvoiceValidator)
            {
                await _mediator.Send(new AddInvoiceExceptionRecordToAirtableCommand() { InvoiceError = error });
            }



            return Ok();
        }


        
    }
}
