using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.InvoiceValidation.Models;
using Microsoft.EntityFrameworkCore;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class AnyMaterialValidator : IMaterialValidator
    {
        public IValidationState State { get; set; } = new Valid();
        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();


        public IValidationState RunValidation(List<ServiceTitanInvoiceItemModel> materialInvoiceItems)
        {
            return (IValidationState) new Valid();

            //if (ml.Type == "Any") //(!materialInvoiceItems.Any(m => mlItems.Any(i => i.MaterialId == m.Sku.Id))))
            //{
            //    var anyMatch = false;
            //    foreach (var listItem in ml.MaterialListItems.AsQueryable().Include(m => m.JobMaterial).ToList())
            //    {
            //        if (materialInvoiceItems.Any(m => m.Sku.Id == listItem.MaterialId))
            //        {
            //            anyMatch = true;
            //        }
            //    }

            //    if (anyMatch == false)
            //    {
            //        var jobAssignment = job.JobAssignments.AsQueryable().Include(j => j.Technician).Where(j => j.Active == true).FirstOrDefault();

            //        result.Add(new FlaggedJobServiceMaterialsDto()
            //        {
            //            FlaggedJobId = Convert.ToInt32(job.JobNumber),
            //            FlaggedMaterialCode = ml.Name,
            //            JobCompletedDate = job.CompletedOn,
            //            TechnicianName = jobAssignment.Technician.Name,
            //            TechnicianId = jobAssignment.Technician.Id
            //            //FlaggedJob = job,
            //            //FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),
            //            //FlaggedMaterialList = ml,
            //            //FlaggedMaterialListItem = listItem
            //        });
            //        link = null;
            //        goto outer_loop;
            //    }





        }

        public IValidationState RunValidation()
        {
            return new Valid();
        }
    }
}
