using A1ServicesApp.Data.Entities.ServiceMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks.Models
{
    public class NewJobServiceMaterialLinkDto
    {
        public int? Active { get; set; }
        public string Name { get; set; }

        public int? ServiceId { get; set; }

        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();

    }
}
