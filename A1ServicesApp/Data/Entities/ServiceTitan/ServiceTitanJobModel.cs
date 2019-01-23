using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanJobModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }
        public string JobNumber { get; set; }
        public int? ProjectId { get; set; }
        public ServiceTitanBusinessUnitModel BusinessUnit { get; set; }
        public ServiceTitanCampaignModel Campaign { get; set; }
        public ServiceTitanTechgeneratedLeadSourceModel TechGeneratedLeadSource { get; set; }
        public ServiceTitanJobTypeModel Type { get; set; }
        public ServiceTitanCustomerModel Customer { get; set; }
        public ServiceTitanLocationModel Location { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ScheduledOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? Duration { get; set; }
        public bool NoCharge { get; set; }
        public ICollection<ServiceTitanTagModel> Tags { get; set; } = new List<ServiceTitanTagModel>();
        public ICollection<ServiceTitanJobAssignmentModel> JobAssignments { get; set; } = new List<ServiceTitanJobAssignmentModel>();
        public ICollection<ServiceTitanEstimateModel> Estimates { get; set; } = new List<ServiceTitanEstimateModel>();
        public ServiceTitanInvoiceModel Invoice { get; set; }
        public ServiceTitanCreatedbyModel CreatedBy { get; set; }
        public ServiceTitanCallModel LeadCall { get; set; }
        public bool ManageEmployeeEmail { get; set; }
        public bool ManageFollowUpEmail { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int? RecallForId { get; set; }
        public bool NotificationsEnabled { get; set; }
    }
}
