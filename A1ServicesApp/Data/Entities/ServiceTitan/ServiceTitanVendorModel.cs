using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanVendorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModifiedOn { get; set; }
        public bool? Active { get; set; }
        public bool? IsTruckReplenishment { get; set; }

    }
}
