using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanPaymentModel
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public bool Active { get; set; }
        public ServiceTitanTypeModel Type { get; set; }
        public double? Amount { get; set; }
        public double? TotalAmount { get; set; }
        public string Memo { get; set; }
        public DateTime PaidOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string SettlementStatus { get; set; }
        public DateTime SettlementDate { get; set; }
        public string BatchName { get; set; }
        public int? BatchId { get; set; }
        public int? BatchNumber { get; set; }

    }
}
