using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanProjectModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Summary { get; set; }
        public ServiceTitanCustomerModel Customer { get; set; }
        public ServiceTitanLocationModel Location { get; set; }
        public ICollection<ServiceTitanJobModel> Jobs { get; set; } = new List<ServiceTitanJobModel>();
        public ICollection<ServiceTitanEstimateModel> Estimates { get; set; } = new List<ServiceTitanEstimateModel>();
        public ICollection<ServiceTitanJobAssignmentModel> JobAssignments { get; set; } = new List<ServiceTitanJobAssignmentModel>();
        public ICollection<ServiceTitanInvoiceModel> Invoices { get; set; } = new List<ServiceTitanInvoiceModel>();
        public ICollection<ServiceTitanInvoiceItemModel> InvoiceItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();
        public ICollection<ServiceTitanPurchaseOrderModel> PurchaseOrders { get; set; } = new List<ServiceTitanPurchaseOrderModel>();
        public ICollection<ServiceTitanCustomFieldApiModel> CustomFields { get; set; } = new List<ServiceTitanCustomFieldApiModel>();
    }
}
