using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanCallModel
    {
        public int? Id { get; set; }
        public string ReceivedOn { get; set; }
        public string Duration { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Direction { get; set; }
        public string CallType { get; set; }
        public ServiceTitanCallReasonModel Reason { get; set; }
        public string RecordingUrl { get; set; }
        public ServiceTitanNamedModel CreatedBy { get; set; }
        public ServiceTitanCustomerModel Customer { get; set; }
        public ServiceTitanCampaignModel Campaign { get; set; }
        public string ModifiedOn { get; set; }
    }
}
