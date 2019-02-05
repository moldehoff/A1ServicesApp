using A1ServicesApp.Data.Entities.ServiceTitan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Models
{
    public class JobsListDto
    {
        public ICollection<ServiceTitanJobModel> Jobs { get; set; } = new List<ServiceTitanJobModel>();
    }
}
