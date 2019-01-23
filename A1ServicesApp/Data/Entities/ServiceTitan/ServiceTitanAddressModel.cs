using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanAddressModel
    {
        public int? Id { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string StreetAddress { get; set; }
        public int? Latitude { get; set; }
        public int? Longitude { get; set; }
    }
}
