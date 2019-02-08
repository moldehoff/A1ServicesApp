using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks.Models
{
    public class TechnicianMissingItemGroupModel
    {
        public string TechnicianName { get; set; }
        public int TechFlaggedJobCount { get; set; }
        public int TechnicianId { get; set; }



        public ICollection<int>  MaterialId { get; set; } = new List<int>();
        public ICollection<string> MaterialCode { get; set; } = new List<string>();
        public ICollection<FlaggedJobServiceMaterialsDto> MaterialLinks { get; set; } = new List<FlaggedJobServiceMaterialsDto>();

    }
}
