using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Features.InvoiceValidation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class AnyMaterialValidator : IMaterialValidator
    {
        public AnyMaterialValidator()
        {
        }

        public IValidationState State { get; set; } = new Valid();
        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();
        public int? ServiceId { get; set; }
        public string ServiceCode { get; set; }


        public void RunValidation(InvoiceValidator invoiceValidator)
        {
            var _materialLists = MaterialLists;
            var _materialInvoiceItems = invoiceValidator.MaterialItems;

            

            foreach (var list in _materialLists.AsQueryable().Include(ml => ml.MaterialListItems).ThenInclude(mli => mli.JobMaterial).ToList())
            {
                var anyMatch = false;
                string flaggedMaterialCode = list.Name.Contains(" - links") ? list.Name.Remove(list.Name.Length - 8) : list.Name;
                

                foreach (var item in list.MaterialListItems)
                {
                    if (_materialInvoiceItems.Any(m => m.Sku.Id == item.MaterialId))
                    {
                        anyMatch = true;

                    }
                }

                if (!anyMatch)
                {
                    this.State = new Invalid();
                    invoiceValidator.SetInvoiceStateInvalid();
                    invoiceValidator.InvoiceErrors.Add(new InvoiceError()
                    {
                        FlaggedJobId = invoiceValidator.Job.Id,
                        ServiceCode = ServiceCode,
                        FlaggedMaterialCode = flaggedMaterialCode,
                        FlaggedMaterialId = 0,
                        JobCompletedDate = invoiceValidator.Job.CompletedOn,
                        TechnicianName = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Name).FirstOrDefault().ToString(),
                        TechnicianId = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Id).FirstOrDefault()
                    });
                }



            }

        }
    }

}

