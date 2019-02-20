using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.InvoiceValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public interface IMaterialValidator
    {
        IValidationState State { get; set; }
        void RunValidation(InvoiceValidator invoiceValidator);
    }
}
