using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanLeadCustomerModel
    {
        public ICollection<ServiceTitanLeadOutputModel> Leads { get; set; }
        public int Id { get; set; }
        public bool? Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public bool? DoNotMail { get; set; }
        public ServiceTitanAddressModel Address { get; set; }
        public string Type { get; set; }
        public ICollection<ServiceTitanContactModel> Contacts { get; set; }
        public int? MergedToId { get; set; }
        public string ModifiedOn { get; set; }
        public ICollection<ServiceTitanMembershipModel> Memberships { get; set; }
        public bool? HasActiveMembership { get; set; }
        public ICollection<ServiceTitanCustomFieldApiModel> CustomFields { get; set; }
        public string CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}
