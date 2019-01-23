using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanEquipmentModel
    {
        public bool Active { get; set; }
        public int Id { get; set; }
        public int? EquipmentId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Memo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int? Cost { get; set; }
        public DateTime InstalledOn { get; set; }
        public DateTime ManufacturerWarrantyStart { get; set; }
        public DateTime ManufacturerWarrantyEnd { get; set; }
        public DateTime ServiceProviderWarrantyStart { get; set; }
        public DateTime ServiceProviderWarrantyEnd { get; set; }

    }
}
