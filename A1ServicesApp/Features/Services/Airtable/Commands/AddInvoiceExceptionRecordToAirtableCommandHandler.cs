using AirtableApiClient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Services.Airtable.Commands
{
    public class AddInvoiceExceptionRecordToAirtableCommandHandler : IRequestHandler<AddInvoiceExceptionRecordToAirtableCommand, Object>
    {
        public Task<Object> Handle(AddInvoiceExceptionRecordToAirtableCommand request, CancellationToken cancellationToken)
        {
            const string airtableApiKey = "keyouw8CITeZrgZqx";
            const string invoiceExceptionBaseKey = "appq4DBeNHZdRSoa1";
            
            var airTableBase = new AirtableBase(airtableApiKey, invoiceExceptionBaseKey);

            var airtableFields = new Fields();
            airtableFields.FieldsCollection.Add("job_id", request.flaggedJob.FlaggedJobId.ToString());
            airtableFields.FieldsCollection.Add("flagged_material_code", request.flaggedJob.FlaggedMaterialCode);
            airtableFields.FieldsCollection.Add("technician_name", request.flaggedJob.TechnicianName);
            airtableFields.FieldsCollection.Add("job_completed_date", DateTime.Parse(request.flaggedJob.JobCompletedDate));
            airtableFields.FieldsCollection.Add("job_url", "https://go.servicetitan.com/#/Job/Index/" + request.flaggedJob.FlaggedJobId.ToString());

            var result = airTableBase.CreateRecord("exception_list", airtableFields, true).Result;


            return Task.FromResult<Object>(result);
        }
    }
}
