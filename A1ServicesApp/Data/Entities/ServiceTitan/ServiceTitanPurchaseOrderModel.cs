using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanPurchaseOrderModel
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public ServiceTitanVideoModel Vendor { get; set; }
        public ServiceTitanEmployeeModel Technician { get; set; }
        public double Amount { get; set; }
        public string Summary { get; set; }
        public string ModifiedOn { get; set; }
        public string Date { get; set; }
        public int? TypeId { get; set; }
        public string Type { get; set; }
        public int? BatchId { get; set; }
        public string SentOn { get; set; }
        public string ReceivedOn { get; set; }
        public double? Tax { get; set; }
        public string JobNumber { get; set; }
        public int? JobId { get; set; }
        public ICollection<ServiceTitanPurchaseOrderItemModel> Items { get; set; } = new List<ServiceTitanPurchaseOrderItemModel>();
        public ICollection<ServiceTitanCustomFieldApiModel> CustomFields { get; set; } = new List<ServiceTitanCustomFieldApiModel>();
        public string PurchaseOrderNumber { get; set; }

    }
}
