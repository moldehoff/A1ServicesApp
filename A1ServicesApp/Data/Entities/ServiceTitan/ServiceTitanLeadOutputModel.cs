using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanLeadOutputModel
    {
        public int? Id { get; set; }
        public string Status { get; set; }
        public bool? Active { get; set; }
        public string Summary { get; set; }
        public string Priority { get; set; }
        public string CreatedOn { get; set; }
        public ServiceTitanEmployeeDetailedModel CreatedBy { get; set; }
        public ServiceTitanLocationModel Location { get; set; }
        public ServiceTitanCampaignModel Campaign { get; set; }
        public ServiceTitanBusinessUnitModel BusinessUnit { get; set; }
        public ServiceTitanJobTypeModel JobType { get; set; }
        public int? CallId { get; set; }
        public int? ManualCallId { get; set; }
        public int? BookingId { get; set; }
        public int? CallReasonId { get; set; }
        public string CallReasonName { get; set; }
        public bool? CallReasonLead { get; set; }
        public bool? CallReasonActive { get; set; }
        public string LatestFollowUpDate { get; set; }

    }
}
