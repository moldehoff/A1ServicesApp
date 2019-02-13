using A1ServicesApp.Features.InvoiceValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class AllMaterialValidator : IMaterialValidator
    {
        public IValidationState State { get; set; } = new Valid();

        public IValidationState RunValidation()
        {
            return new Valid();
        }
    }
}
