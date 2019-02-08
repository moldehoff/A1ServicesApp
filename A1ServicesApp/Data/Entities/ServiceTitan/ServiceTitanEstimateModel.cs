using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanEstimateModel
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public string Name { get; set; }
        public string JobNumber { get; set; }
        public ServiceTitanEstimateStatusModel Status { get; set; }
        public string Summary { get; set; }
        public ICollection<ServiceTitanItemModel> Items { get; set; } = new List<ServiceTitanItemModel>();
        public DateTime ModifiedOn { get; set; }
    }
}
