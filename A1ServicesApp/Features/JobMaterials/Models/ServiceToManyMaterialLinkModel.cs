using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Models
{
    public class ServiceToManyMaterialLinkModel
    {
        public int ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public ICollection<MaterialModel> Materials { get; set; }

    }
}
