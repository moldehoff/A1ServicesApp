using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanMembershipModel
    {
        public int? Id { get; set; }
        public bool? Active { get; set; }
        public ServiceTitanTypeModel Type { get; set; }
        public string Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int? LocationId { get; set; }
    }
}
