﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class InvalidInvoice : IInvoiceValidationState
    {
        public IInvoiceValidationState SetInvalid() => this;

        public IInvoiceValidationState SetValid() => this;
    }
}
