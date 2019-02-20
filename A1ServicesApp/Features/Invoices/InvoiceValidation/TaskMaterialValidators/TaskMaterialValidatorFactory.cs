using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.InvoiceValidation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class TaskMaterialValidatorFactory
    {
        private A1ServicesAppDbContext _ctx;

        public TaskMaterialValidatorFactory(A1ServicesAppDbContext ctx)
        {
            _ctx = ctx;
        }
        public TaskMaterialValidatorFactory()
        {

        }

        public List<IMaterialValidator> CreateMaterialValidators(List<ServiceTitanInvoiceItemModel> serviceItems)
        {
            var validators = new List<IMaterialValidator>();
            var jobMatLinks = new List<JobServiceMaterialLink>();
            var links = _ctx.JobServiceMaterialLinks.Include(j=>j.MaterialLists).ThenInclude(ml=>ml.MaterialListItems).ThenInclude(mli=>mli.JobMaterial).ToList();

            foreach (var item in serviceItems)
            {
                jobMatLinks.AddRange(links.Where(l => l.ServiceId == item.Sku.Id));
            }

            foreach (var j in jobMatLinks)
            {
                foreach (var l in j.MaterialLists)
                {
                    if (l.Type == "Any")
                    {
                        validators.Add(ConvertToAnyMaterialValidators(l, j));
                    }
                    else if (l.Type == "All")
                    {
                        validators.Add(ConvertToAllMaterialValidators(l, j));
                    }
                }
            }

            return validators;
        }

        private IMaterialValidator ConvertToAnyMaterialValidators(MaterialList list, JobServiceMaterialLink link)
        {
            var validator = (IMaterialValidator) new AnyMaterialValidator()
            {
                ServiceCode = link.ServiceCode,
                ServiceId = link.ServiceId,
                State = new Valid(),
                MaterialLists = new List<MaterialList>()
                {
                    new MaterialList(list)
                }
            };

            return validator;
        }

        private IMaterialValidator ConvertToAllMaterialValidators(MaterialList list, JobServiceMaterialLink link)
        {
            var validator = (IMaterialValidator) new AllMaterialValidator()
            {
                ServiceCode = link.ServiceCode,
                ServiceId = link.ServiceId,
                State = new Valid(),
                MaterialLists = new List<MaterialList>()
                {
                    new MaterialList(list)
                }
            };

            return validator;
        }
    }
}
