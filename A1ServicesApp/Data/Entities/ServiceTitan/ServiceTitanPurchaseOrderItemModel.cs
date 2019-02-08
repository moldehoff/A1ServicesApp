using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanPurchaseOrderItemModel
    {
        public int? Id { get; set; }
        public int? SkuId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Cost { get; set; }
        public double Total { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public bool? Chargeable { get; set; }
        public int? MaterialVendorId { get; set; }
        public int? BusinessUnitId { get; set; }

    }
}
