using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanPayrollAdjustmentApiModel
    {
        public int? Id { get; set; }
        public int? InvoiceId { get; set; }
        public int TechnicianId { get; set; }
        public string PostedOn { get; set; }
        public double? Rate { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }
        public string Memo { get; set; }
        public string Type { get; set; }

    }
}
