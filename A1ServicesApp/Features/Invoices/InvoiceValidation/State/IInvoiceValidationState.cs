using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public interface IInvoiceValidationState
    {
        IInvoiceValidationState SetInvalid();
        IInvoiceValidationState SetValid();
    }
}
