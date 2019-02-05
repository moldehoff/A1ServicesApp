using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.JobMaterials.Models;
using A1ServicesApp.Features.JobServiceMaterialLinks.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Queries
{
    public class FindJobsWithMismatchedJobMaterialsQuery : IRequest<List<FlaggedJobServiceMaterialsDto>>
    {
        public ICollection<ServiceTitanJobModel> Jobs { get; set; } = new List<ServiceTitanJobModel>();
    }
}
