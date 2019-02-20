using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanEstimateItemModel
    {
        public int? Id { get; set; }
        public ServiceTitanSkuModel Sku { get; set; }
        public string SkuAccount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string MembershipTypeId { get; set; }
        public float? qty { get; set; }
        public float? UnitRate { get; set; }
        public float? Total { get; set; }
        public float? Tax { get; set; }
        public float? Subtotal { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupRootId { get; set; }
        public string ModifiedOn { get; set; }

    }
}
