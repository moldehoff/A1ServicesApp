using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class ValidInvoice : IInvoiceValidationState
    {
        public IInvoiceValidationState SetInvalid() => new InvalidInvoice();
        
        public IInvoiceValidationState SetValid() => this;
    }
}
