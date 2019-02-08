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
    public class GetJobServiceByIdQueryHandler : IRequestHandler<GetJobServiceByIdQuery, JobServiceDto>
    {
        private IMapper _mapper;
        private A1ServicesAppDbContext _ctx;

        public GetJobServiceByIdQueryHandler(IMapper mapper, A1ServicesAppDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public Task<JobServiceDto> Handle(GetJobServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<JobServiceDto>(_ctx.JobServices.Where(j => j.Id == request.ServiceId).FirstOrDefault());

            return Task.FromResult<JobServiceDto>(result);
        }
    }
}
