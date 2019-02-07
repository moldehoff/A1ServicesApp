using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Features.JobMaterials.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobMaterials.Queries
{
    public class GetAllJobMaterialLinksQueryHandler : IRequestHandler<GetAllJobMaterialLinksQuery, List<JobServiceMaterialLink>>
    {
        private IMapper _mapper;
        private A1ServicesAppDbContext _ctx;

        public GetAllJobMaterialLinksQueryHandler(A1ServicesAppDbContext ctx, IMapper mapper)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public Task<List<JobServiceMaterialLink>> Handle(GetAllJobMaterialLinksQuery request, CancellationToken cancellationToken)
        {
            var links = _ctx.JobServiceMaterialLinks.Include(js => js.MaterialLists).ThenInclude(ml => ml.MaterialListItems).ToList();

            return Task.FromResult<List<JobServiceMaterialLink>>(links);
        }
    }
}
