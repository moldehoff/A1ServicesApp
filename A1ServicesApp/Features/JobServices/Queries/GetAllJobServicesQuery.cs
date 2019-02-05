using A1ServicesApp.Features.JobServices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServices.Queries
{
    public class GetAllJobServicesQuery : IRequest<List<JobServiceDto>>
    {
        
    }
}
