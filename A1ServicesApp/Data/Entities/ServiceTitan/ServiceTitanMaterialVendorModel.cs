using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanMaterialVendorModel
    {
        public int? Id { get; set; }
        public string VendorName { get; set; }
        public int VendorId { get; set; }
        public string Memo { get; set; }
        public string VendorPart { get; set; }
        public double? Cost { get; set; }
        public bool? Active { get; set; }

    }
}
