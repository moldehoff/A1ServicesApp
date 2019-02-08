using A1ServicesApp.Data;
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
    public class GetJobServiceMaterialLinkByIdQueryHandler : IRequestHandler<GetJobServiceMaterialLinkByIdQuery, JobServiceMaterialLinkDto>
    {
        private IMapper _mapper;
        private A1ServicesAppDbContext _ctx;

        public GetJobServiceMaterialLinkByIdQueryHandler(IMapper mapper, A1ServicesAppDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public Task<JobServiceMaterialLinkDto> Handle(GetJobServiceMaterialLinkByIdQuery request, CancellationToken cancellationToken)
        {
            var link = _ctx.JobServiceMaterialLinks.Where(j => j.Id == request.Id)
                .Include(js => js.MaterialLists)
                    .ThenInclude(ml => ml.MaterialListItems)
                .FirstOrDefault();

            var result = _mapper.Map<JobServiceMaterialLinkDto>(link);

            return Task.FromResult<JobServiceMaterialLinkDto>(result);
        }
    }
}
