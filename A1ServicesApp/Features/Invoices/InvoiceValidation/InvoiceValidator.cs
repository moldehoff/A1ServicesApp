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
        private A1ServicesAppDbContext _ctx;
        private TaskMaterialValidatorFactory _materialValidatorFactory;

        public ServiceTitanJobModel Job { get; set; }
        public ServiceTitanInvoiceModel Invoice { get; set; }
        public IInvoiceValidationState ValidationState { get; set; } = new ValidInvoice();

        public ICollection<ServiceTitanInvoiceItemModel> ServiceItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();
        public ICollection<ServiceTitanInvoiceItemModel> MaterialItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();

        public ICollection<IMaterialValidator> MaterialValidators { get; set; } = new List<IMaterialValidator>();

        public ICollection<InvoiceError> InvoiceErrors { get; set; } = new List<InvoiceError>();

        public InvoiceValidator(ServiceTitanJobModel jobModel, A1ServicesAppDbContext ctx)
        {
            _ctx = ctx;
            var materialValidatorFactory = new TaskMaterialValidatorFactory(_ctx);
            _materialValidatorFactory = materialValidatorFactory;

            Job = jobModel;
            Invoice = jobModel.Invoice;
            ValidationState = new ValidInvoice();
            ServiceItems = jobModel.Invoice.Items.Where(i => i.Active == true).Where(i=> i.Sku.Type == "Service").ToList();
            MaterialItems = jobModel.Invoice.Items.Where(i => i.Active == true).Where(i=>i.Sku.Type == "Material").ToList();
            MaterialValidators = CreateValidators();

        }

        public InvoiceValidator()
        {

        }

        public List<IMaterialValidator> CreateValidators()
        {
            var materialValidatorList = new List<IMaterialValidator>();
            materialValidatorList.AddRange(_materialValidatorFactory.CreateMaterialValidators(ServiceItems.ToList()));

            return materialValidatorList;
        }

        public void RunMaterialValidators()
        {
            foreach (var item in MaterialItems)
            {
                if (item.Qty <= 0)
                {
                    SetInvoiceStateInvalid();
                    InvoiceErrors.Add(new InvoiceError()
                    {
                        
                        FlaggedJobId = Job.Id,
                        FlaggedMaterialCode = item.Sku.Name,
                        FlaggedMaterialId = item.Sku.Id,
                        JobCompletedDate = Job.CompletedOn,
                        TechnicianName = Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Name).FirstOrDefault()?.ToString(),
                        TechnicianId = Job.JobAssignments.Any(j => j.Active == true) ? Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Id).FirstOrDefault() : 0,
                        JobType = Job.Type.Name
                    });
                }
            }

            Parallel.ForEach(MaterialValidators, m => m.RunValidation(this));
        }

        public void SetInvoiceStateInvalid()
        {
            this.ValidationState.SetInvalid();
        }

        public void SetInvoiceStateValid()
        {
            this.ValidationState.SetValid();
        }
    }
}
