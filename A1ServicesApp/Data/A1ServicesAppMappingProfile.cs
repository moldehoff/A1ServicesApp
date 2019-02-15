using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.JobMaterials.Models;
using A1ServicesApp.Features.JobServices.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data
{
    public class A1ServicesAppMappingProfile : Profile
    {
        public A1ServicesAppMappingProfile()
        {
            CreateMap<JobServiceMaterialLink, JobServiceMaterialLinkDto>().ReverseMap();
            CreateMap<JobService, JobServiceDto>().ReverseMap();
            CreateMap<JobMaterial, JobMaterialDto>().ReverseMap();

            CreateMap<ServiceTitanPostJobCompleted_ResultModel, ServiceTitanJobModel>();

        }
    }
}
