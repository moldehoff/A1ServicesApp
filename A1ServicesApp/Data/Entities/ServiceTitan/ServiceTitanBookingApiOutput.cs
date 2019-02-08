using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanBookingApiOutput
    {
        public string CustomerType { get; set; }
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Source { get; set; }
        public string CreatedOn { get; set; }
        public bool Active { get; set; }
        public string Start { get; set; }
        public string Summary { get; set; }
        public ServiceTitanAddressModel Address { get; set; }
        public string Customer { get; set; }
        public ICollection<ServiceTitanContactModel> Contacts { get; set; } = new List<ServiceTitanContactModel>();
        public ServiceTitanJobModel Job { get; set; }
        public bool? IsFirstTimeClient { get; set; }
        public ICollection<string> UploadedImages { get; set; } = new List<string>();
        public bool? IsSendConfirmationEmail { get; set; }
        public int? BusinessUnitId { get; set; }
        public string Status { get; set; }
        public string AgentTag { get; set; }
        public ServiceTitanCallReasonModel DismissingReason { get; set; }


    }
}
