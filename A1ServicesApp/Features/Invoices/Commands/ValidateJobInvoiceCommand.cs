using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.InvoiceValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Invoices.Commands
{
    public class ValidateJobInvoiceCommand : IRequest<List<InvoiceError>>
    {
        public ServiceTitanJobModel Job { get; set; }

    }
}
