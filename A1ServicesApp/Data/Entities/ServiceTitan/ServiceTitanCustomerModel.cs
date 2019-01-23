using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanCustomerModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Balance { get; set; }
        public bool DoNotMail { get; set; }
        public ServiceTitanAddressModel Address { get; set; }
        public bool DoNotService { get; set; }
        public string Type { get; set; }
        public ICollection<ServiceTitanContactModel> Contacts { get; set; } = new List<ServiceTitanContactModel>();
        public int? MergedToId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public ICollection<ServiceTitanMembershipModel> Memberships { get; set; } = new List<ServiceTitanMembershipModel>();
        public bool HasActiveMembership { get; set; }
        public ICollection<ServiceTitanCustomFieldApiModel> CustomFields { get; set; } = new List<ServiceTitanCustomFieldApiModel>();
    }
}
