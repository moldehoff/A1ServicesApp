using A1ServicesApp.Data;
using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;
using A1ServicesApp.Features.Jobs.Models;
using A1ServicesApp.Features.Jobs.Queries;
using A1ServicesApp.Features.Services.Airtable.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace A1ServicesApp.Features.InvoiceValidation
{
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private IMediator _mediator;
        private A1ServicesAppDbContext _ctx;

        public InvoiceController(IMediator mediator, A1ServicesAppDbContext ctx)
        {
            _mediator = mediator;
            _ctx = ctx;
        }

        [HttpGet("validate")]
        public IActionResult RunInvoiceValidators()
        {
            var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);

            var queryStringModel = new GetJobsQueryStringModel()
            {
                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",
                CompletedBefore = new FilterCompletedBefore() { FilterValue = todaysDate.AddDays(1) },
                CompletedAfter = new FilterCompletedAfter() { FilterValue = todaysDate.AddDays(0) }
            };

            var getJobsFromST = _mediator.Send(new GetJobsFromServiceTitanQuery(queryStringModel)).Result;

            var invoiceValidators = new List<InvoiceValidator>();
            var invoicesWithErrors = new List<InvoiceValidator>();
            var errorReports = new List<InvoiceError>();
            foreach (var job in getJobsFromST.ApiResults)
            {
                invoiceValidators.Add(new InvoiceValidator(job, _ctx));
            }

            

            foreach (var i in invoiceValidators)
            {
                i.RunMaterialValidators();
                if (i.InvoiceErrors.Count > 0)
                {
                    invoicesWithErrors.Add(i);
                }
            }
            foreach (var i in invoicesWithErrors)
            {
                errorReports.AddRange(i.InvoiceErrors);
                foreach (var e in i.InvoiceErrors)
                {
                    _mediator.Send(new AddInvoiceExceptionRecordToAirtableCommand() { InvoiceError = e });
                }
                
            }

            return Ok(errorReports);
        }
    }
}
