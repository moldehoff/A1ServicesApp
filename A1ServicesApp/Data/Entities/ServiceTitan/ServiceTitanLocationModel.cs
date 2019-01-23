using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanLocationModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ServiceTitanCustomerModel Customer { get; set; }
        public ServiceTitanAddressModel Address { get; set; }
        public ICollection<ServiceTitanContactModel> Contacts { get; set; } = new List<ServiceTitanContactModel>();
        public int? MergedToId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public ServiceTitanZoneModel Zone { get; set; }
        public ICollection<ServiceTitanCustomFieldApiModel> CustomFields { get; set; } = new List<ServiceTitanCustomFieldApiModel>();
        public ICollection<ServiceTitanEquipmentModel> Equipment { get; set; } = new List<ServiceTitanEquipmentModel>();

    }
}
