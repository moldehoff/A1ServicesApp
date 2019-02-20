using A1ServicesApp.Data;
using A1ServicesApp.Features.InvoiceValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Invoices.Commands
{
    public class ValidateJobInvoiceCommandHandler : IRequestHandler<ValidateJobInvoiceCommand, List<InvoiceError>>
    {
        private A1ServicesAppDbContext _ctx;

        public ValidateJobInvoiceCommandHandler(A1ServicesAppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<InvoiceError>> Handle(ValidateJobInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceError>();

            var invoiceValidator = new InvoiceValidator(request.Job, _ctx);

            if (invoiceValidator.MaterialValidators.Any())
            {
                invoiceValidator.RunMaterialValidators();
            }

            result.AddRange(invoiceValidator.InvoiceErrors);

            return Task.FromResult<List<InvoiceError>>(result);
        }
    }
}
