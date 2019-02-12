using A1ServicesApp.Features.JobServiceMaterialLinks.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Services.Airtable.Commands
{
    public class AddInvoiceExceptionRecordToAirtableCommand : IRequest<Object>
    {
        public FlaggedJobServiceMaterialsDto flaggedJob { get; set; }

    }
}
