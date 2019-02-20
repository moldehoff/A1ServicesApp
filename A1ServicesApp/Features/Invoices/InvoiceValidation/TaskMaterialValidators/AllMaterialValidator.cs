using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Features.InvoiceValidation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class AllMaterialValidator : IMaterialValidator
    {
        public IValidationState State { get; set; } = new Valid();
        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();
        public int? ServiceId { get; set; }
        public string ServiceCode { get; set; }

        public void RunValidation(InvoiceValidator invoiceValidator)
        {
            var _materialLists = MaterialLists;
            var _materialInvoiceItems = invoiceValidator.MaterialItems;

            foreach (var ml in _materialLists)
            {
                foreach (var listItem in ml.MaterialListItems.AsQueryable().Include(m => m.JobMaterial).ThenInclude(jm=>jm.MaterialId).ToList())
                {
                    if (!_materialInvoiceItems.Any(m => m.Sku.Id == listItem.MaterialId))
                    {
                        this.State = new Invalid();
                        invoiceValidator.SetInvoiceStateInvalid();
                        invoiceValidator.InvoiceErrors.Add(new InvoiceError()
                        {
                            FlaggedJobId = invoiceValidator.Job.Id,
                            ServiceCode = ServiceCode,
                            FlaggedMaterialCode = listItem.JobMaterial.Code,
                            FlaggedMaterialId = listItem.JobMaterial.MaterialId,
                            JobCompletedDate = invoiceValidator.Job.CompletedOn,
                            TechnicianName = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Name).FirstOrDefault().ToString(),
                            TechnicianId = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Id).FirstOrDefault()
                        });
                        continue;
                        
                    }

                }
            }

            
        }
    }
}
