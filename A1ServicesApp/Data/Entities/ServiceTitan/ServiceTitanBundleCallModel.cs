using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanBundleCallModel
    {
        public int? Id { get; set; }
        public string JobNumber { get; set; }
        public int? ProjectId { get; set; }
        public ServiceTitanBusinessUnitModel BusinessUnit { get; set; }
        public ServiceTitanJobTypeModel Type { get; set; }
        public ServiceTitanCallModel LeadCall { get; set; }

    }
}
