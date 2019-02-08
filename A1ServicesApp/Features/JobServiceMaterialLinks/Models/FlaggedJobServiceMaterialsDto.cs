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
        public int FlaggedJobId { get; set; }
        public string FlaggedMaterialCode { get; set; }
        public int FlaggedMaterialId { get; set; }
        public string JobCompletedDate { get; set; }
        public string TechnicianName { get; set; }
        public int TechnicianId { get; set; }

    }
}
