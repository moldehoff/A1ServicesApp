using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanInvoiceModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int? AdjustmentToId { get; set; }
        public int? JobId { get; set; }
        public string JobNumber { get; set; }
        public ServiceTitanInvoiceStatusModel Status { get; set; }
        public string BatchName { get; set; }
        public int? BatchId { get; set; }
        public int? BatchNumber { get; set; }
        public string Summary { get; set; }
        public string Number { get; set; }
        public string InvoicedOn { get; set; }
        public string CommissionEligibilityDate { get; set; }
        public double? Tax { get; set; }
        public double? Subtotal { get; set; }
        public double? Total { get; set; }
        public double? Balance { get; set; }
        public ICollection<ServiceTitanInvoiceItemModel> Items { get; set; } = new List<ServiceTitanInvoiceItemModel>();
        public ICollection<ServiceTitanPaymentModel> Payments { get; set; } = new List<ServiceTitanPaymentModel>();
        public ICollection<ServiceTitanPurchaseOrderModel> PurchaseOrders { get; set; } = new List<ServiceTitanPurchaseOrderModel>();
        public string RoyaltyStatus { get; set; }
        public string RoyaltyDate { get; set; }
        public string RoyaltySentOn { get; set; }
        public string RoyaltyMemo { get; set; }
        public string ModifiedOn { get; set; }
    }
}
