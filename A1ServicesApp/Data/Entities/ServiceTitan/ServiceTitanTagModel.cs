using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanTagModel
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string Name { get; set; }
    }
}
