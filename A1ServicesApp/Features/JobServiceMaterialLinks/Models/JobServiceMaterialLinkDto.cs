using A1ServicesApp.Data.Entities.ServiceMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Models
{
    public class JobServiceMaterialLinkDto
    {
        public int? Id { get; set; }
        public int? Active { get; set; }
        public string Name { get; set; }

        public int? ServiceId { get; set; }
        public string ServiceCode { get; set; }

        public ICollection<MaterialList> MaterailLists { get; set; } = new List<MaterialList>();
    }
}
