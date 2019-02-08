using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Models
{
    public class ServiceMaterialsLinksDto
    {
        public int ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public int Quantity { get; set; }
        public int Active { get; set; }

    }
}
