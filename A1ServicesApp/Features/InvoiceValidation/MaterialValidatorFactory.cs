using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Data.Entities.ServiceTitan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class MaterialValidatorFactory
    {
        private A1ServicesAppDbContext _ctx;

        public MaterialValidatorFactory(A1ServicesAppDbContext ctx)
        {
            _ctx = ctx;
        }
        public MaterialValidatorFactory()
        {

        }

        public List<IMaterialValidator> CreateMaterialValidators(List<ServiceTitanInvoiceItemModel> items)
        {
            var validators = new List<IMaterialValidator>();
            var jobMatLinks = new List<JobServiceMaterialLink>();
            var links = _ctx.JobServiceMaterialLinks.ToList();

            foreach (var item in items)
            {
                jobMatLinks.AddRange(links.Where(l => l.ServiceId == item.Sku.Id));
            }

            foreach (var j in jobMatLinks)
            {
                foreach (var l in j.MaterialLists)
                {
                    if (l.Type == "Any")
                    {
                        validators.Add(ConvertToAnyMaterialValidators(l));
                    }
                    else if (l.Type == "All")
                    {
                        validators.Add(ConvertToAllMaterialValidators(l));
                    }
                }
            }

            return validators;
        }

        private IMaterialValidator ConvertToAnyMaterialValidators(MaterialList list)
        {
            var validator = (IMaterialValidator) new AnyMaterialValidator()
            {
                MaterialLists = new List<MaterialList>()
                {
                    new MaterialList(list)
                }
            };

            return validator;
        }

        private IMaterialValidator ConvertToAllMaterialValidators(MaterialList list)
        {
            var validator = (IMaterialValidator) new AllMaterialValidator();

            return validator;
        }
    }
}
