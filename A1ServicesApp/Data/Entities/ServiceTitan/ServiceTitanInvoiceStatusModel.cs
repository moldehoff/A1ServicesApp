using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanInvoiceStatusModel
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public string Name { get; set; }
        public string DepositedOn { get; set; }
    }
}