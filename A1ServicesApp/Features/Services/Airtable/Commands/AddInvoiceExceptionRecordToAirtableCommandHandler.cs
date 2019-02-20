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
            if (request.FlaggedJob != null)
            {
                airtableFields.FieldsCollection.Add("job_id", request.FlaggedJob.FlaggedJobId.ToString());
                airtableFields.FieldsCollection.Add("flagged_material_code", request.FlaggedJob.FlaggedMaterialCode);
                airtableFields.FieldsCollection.Add("technician_name", request.FlaggedJob.TechnicianName);
                airtableFields.FieldsCollection.Add("job_completed_date", DateTime.Parse(request.FlaggedJob.JobCompletedDate));
                airtableFields.FieldsCollection.Add("job_url", "https://go.servicetitan.com/#/Job/Index/" + request.FlaggedJob.FlaggedJobId.ToString());
                airtableFields.FieldsCollection.Add("service_code", request.FlaggedJob.ServiceCode);
            }
            if (request.InvoiceError != null)
            {
                airtableFields.FieldsCollection.Add("job_id", request.InvoiceError.FlaggedJobId.ToString());
                airtableFields.FieldsCollection.Add("flagged_material_code", request.InvoiceError.FlaggedMaterialCode);
                airtableFields.FieldsCollection.Add("technician_name", request.InvoiceError.TechnicianName);
                airtableFields.FieldsCollection.Add("job_completed_date", DateTime.Parse(request.InvoiceError.JobCompletedDate));
                airtableFields.FieldsCollection.Add("job_url", "https://go.servicetitan.com/#/Job/Index/" + request.InvoiceError.FlaggedJobId.ToString());
                airtableFields.FieldsCollection.Add("service_code", request.InvoiceError.ServiceCode);
            }

            var result = airTableBase.CreateRecord("exception_list", airtableFields, true).Result;


            return Task.FromResult<Object>(result);
        }
    }
}
