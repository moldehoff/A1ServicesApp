using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanPostJobCompleted_ResultModel
    {
        public int? HistoryItemId { get; set; }
        public string EventId { get; set; }
        public int? WebhookId { get; set; }
        public ServiceTitanWebHookEventInfo __EventInfo { get; set; }
        public ServiceTitanWebhookTenantInfo __TenantInfo { get; set; }
        public int? Id { get; set; }
        public bool? Active { get; set; }
        public string Status { get; set; }
        public string JobNumber { get; set; }
        public int? ProjectId { get; set; }
        public ServiceTitanBusinessUnitModel BusinessUnit { get; set; }
        public ServiceTitanCampaignModel Campaign { get; set; }
        public ServiceTitanTechgeneratedLeadSourceModel TechGeneratedLeadSourceModel { get; set; }
        public ServiceTitanJobTypeModel Type { get; set; }
        public ServiceTitanCustomerModel Customer { get; set; }
        public ServiceTitanLocationModel Location { get; set; }
        public string Summary { get; set; }
        public string CreatedOn { get; set; }
        public string ScheduledOn { get; set; }
        public string CompletedOn { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public float? Duration { get; set; }
        public string ArrivalWindowStart { get; set; }
        public string ArrivalWindowEnd { get; set; }
        public bool? NoCharge { get; set; }
        public ICollection<ServiceTitanTagModel> Tags { get; set; } = new List<ServiceTitanTagModel>();
        public ICollection<ServiceTitanJobAssignmentModel> JobAssignments { get; set; } = new List<ServiceTitanJobAssignmentModel>();
        public ICollection<ServiceTitanEstimateModel> Estimates { get; set; } = new List<ServiceTitanEstimateModel>();
        public ServiceTitanInvoiceModel Invoice { get; set; }
        public ServiceTitanEmployeeDetailedModel CreatedBy { get; set; }
        public ServiceTitanCallModel LeadCall { get; set; }
        public bool? ManageEmployeeEmail { get; set; }
        public bool? ManageFollowUpEmail { get; set; }
        public string ModifiedOn { get; set; }
        public int? RecallForId { get; set; }
        public bool? NotificationsEnabled { get; set; }
        public ICollection<ServiceTitanCustomFieldApiModel> CustomFields { get; set; } = new List<ServiceTitanCustomFieldApiModel>();

    }
}
