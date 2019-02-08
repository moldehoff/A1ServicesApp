using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Features.JobMaterials.Models;
using A1ServicesApp.Features.JobServiceMaterialLinks.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServiceMaterialLinks.Commands
{
    public class CreateNewJobServiceMaterialLinkCommand : IRequest<JobServiceMaterialLinkDto>
    {
        public int? Active { get; set; }
        public string Name { get; set; }

        public int? ServiceId { get; set; }

        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();


        public CreateNewJobServiceMaterialLinkCommand(NewJobServiceMaterialLinkDto model)
        {
            Active = model.Active;
            Name = model.Name;
            ServiceId = model.ServiceId;
            MaterialLists = model.MaterialLists; 
        }
    }

}
