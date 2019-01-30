using A1ServicesApp.Data.Entities.ServiceTitan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.Jobs.Models
{
    public class ServiceTitanJobsListDto
    {
        public ServiceTitanEntityCollectionResult<ServiceTitanJobModel> ApiResults { get; set; }

    }
}
