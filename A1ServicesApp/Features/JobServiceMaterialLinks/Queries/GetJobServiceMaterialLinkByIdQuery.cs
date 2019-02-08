using A1ServicesApp.Features.JobMaterials.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Queries
{
    public class GetJobServiceMaterialLinkByIdQuery : IRequest<JobServiceMaterialLinkDto>
    {
        public int Id { get; set; }

    }
}
