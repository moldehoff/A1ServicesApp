using A1ServicesApp.Features.JobMaterials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks.Models
{
    public class MissingItemGroupModel
    {
        public string MaterialCode { get; set; }
        public int MissingMaterialCount { get; set; }
        public int MaterialId { get; set; }

        

        public ICollection<int> TechnicianId { get; set; } = new List<int>();
        public ICollection<string> TechnicianName { get; set; } = new List<string>();
        public ICollection<FlaggedJobServiceMaterialsDto> MaterialLinks { get; set; } = new List<FlaggedJobServiceMaterialsDto>();
    }
}
