using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Features.JobMaterials.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks.Commands
{
    public class CreateNewJobServiceMaterialLinkCommandHandler : IRequestHandler<CreateNewJobServiceMaterialLinkCommand, JobServiceMaterialLinkDto>
    {
        private IMapper _mapper;
        private A1ServicesAppDbContext _ctx;

        public CreateNewJobServiceMaterialLinkCommandHandler(IMapper mapper, A1ServicesAppDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public Task<JobServiceMaterialLinkDto> Handle(CreateNewJobServiceMaterialLinkCommand request, CancellationToken cancellationToken)
        {
            var jobService = _ctx.JobServices.Where(s => s.ServiceId == request.ServiceId).FirstOrDefault();
            var materialLists = request.MaterialLists.ToList();

            var jobMaterials = new List<JobMaterial>();
            var newMaterialLists = new List<MaterialList>();

            foreach (var list in request.MaterialLists)
            {
                var allMaterialListItems = new List<MaterialListItem>();
                foreach (var m in list.MaterialListItems)
                {
                    var material =_ctx.JobMaterials.Where(jm => jm.MaterialId == m.MaterialId).FirstOrDefault();
                    var newMaterialListItem = new MaterialListItem()
                    {
                        MaterialId = material.MaterialId,
                        JobMaterialId = material.Id
                    };
                    allMaterialListItems.Add(newMaterialListItem);
                }
                list.MaterialListItems = allMaterialListItems;
                newMaterialLists.Add(list);
            }



            var newJobServiceMaterialLink = new JobServiceMaterialLink()
            {
                Active = request.Active,
                Name = request.Name,
                ServiceId = request.ServiceId,
                ServiceCode = jobService.Code,
                MaterialLists = newMaterialLists

            };

            _ctx.JobServiceMaterialLinks.Add(newJobServiceMaterialLink);
            _ctx.SaveChanges();



            return Task.FromResult<JobServiceMaterialLinkDto>(_mapper.Map<JobServiceMaterialLinkDto>(newJobServiceMaterialLink));
        }
    }
}
