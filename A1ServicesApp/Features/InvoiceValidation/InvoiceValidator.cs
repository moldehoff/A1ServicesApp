using A1ServicesApp.Data;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.InvoiceValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class InvoiceValidator
    {
        public ServiceTitanJobModel Job { get; set; }
        public ServiceTitanInvoiceModel Invoice { get; set; }
        public IInvoiceValidationState ValidationState { get; set; }

        public ICollection<ServiceTitanInvoiceItemModel> ServiceItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();
        public ICollection<ServiceTitanInvoiceItemModel> MaterialItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();

        public ICollection<IMaterialValidator> MaterialValidators { get; set; } = new List<IMaterialValidator>();

        public InvoiceValidator(ServiceTitanJobModel jobModel)
        {
            var materialValidatorFactory = new MaterialValidatorFactory();

            Job = jobModel;
            Invoice = jobModel.Invoice;
            ValidationState = new ValidInvoice();
            ServiceItems = jobModel.Invoice.Items.Where(i => i.Sku.Type == "Service").ToList();
            MaterialItems = jobModel.Invoice.Items.Where(i => i.Sku.Type == "Material").ToList();
            MaterialValidators = materialValidatorFactory.CreateMaterialValidators(MaterialItems.ToList());

        }
    }
}
