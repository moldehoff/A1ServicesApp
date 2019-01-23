using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanCreatedbyModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LoginName { get; set; }
        public string Role { get; set; }
        public int? BusinessUnitId { get; set; }
        public bool Active { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
