using A1ServicesApp.Data;
using A1ServicesApp.Features.JobServices.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServices.Queries
{
    public class GetAllJobServicesQueryHandler : IRequestHandler<GetAllJobServicesQuery, List<JobServiceDto>>
    {
        private IMapper _mapper;
        private A1ServicesAppDbContext _ctx;

        public GetAllJobServicesQueryHandler(IMapper mapper, A1ServicesAppDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public Task<List<JobServiceDto>> Handle(GetAllJobServicesQuery request, CancellationToken cancellationToken)
        {
            var servicesList = _ctx.JobServices.ToList();

            var result = _mapper.Map<List<JobServiceDto>>(servicesList);

            return Task.FromResult<List<JobServiceDto>>(result);
        }
    }
}
