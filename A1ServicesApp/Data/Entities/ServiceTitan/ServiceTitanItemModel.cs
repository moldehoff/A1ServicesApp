using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanItemModel
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public bool Active { get; set; }
        public ServiceTitanSkuModel Sku { get; set; }
        public string SalesType { get; set; }
        public string Description { get; set; }
        public string MembershipTypeId { get; set; }
        public float? Qty { get; set; }
        public double? UnitRate { get; set; }
        public double? Total { get; set; }
        public double? TotalCost { get; set; }
        public string ItemGroupName { get; set; }
        public int? ItemGroupRootId { get; set; }
        public string ModifiedOn { get; set; }
        public int? Order { get; set; }
    }
}
