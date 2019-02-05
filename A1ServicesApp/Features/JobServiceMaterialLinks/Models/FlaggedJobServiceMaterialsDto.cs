using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.JobMaterials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks.Models
{
    public class FlaggedJobServiceMaterialsDto
    {
        public ServiceTitanJobModel FlaggedJob { get; set; }
        public JobServiceMaterialLinkDto FlaggedLink { get; set; }
        public MaterialList FlaggedMaterialList { get; set; }

    }
}
