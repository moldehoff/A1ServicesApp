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
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? LocationId { get; set; }

    }
}
