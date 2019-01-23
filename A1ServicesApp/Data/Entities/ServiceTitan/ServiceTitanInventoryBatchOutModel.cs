using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanInventoryBatchOutModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public ServiceTitanInventoryBatchStatusModel Status { get; set; }

    }
}
