using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanBusinessUnitTenantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuickbooksClass { get; set; }
        public string AccountCode { get; set; }
        public string FranchiseId { get; set; }
        public string ConceptCode { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
