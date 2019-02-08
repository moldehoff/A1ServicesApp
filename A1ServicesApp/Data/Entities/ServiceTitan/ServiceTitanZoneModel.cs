using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanZoneModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public ICollection<ServiceTitanZips> Zips { get; set; }
        public ICollection<ServiceTitanCity> Cities { get; set; }
        public ICollection<ServiceTitanTerritoryNumber> TerritoryNumbers { get; set; }
        public ICollection<ServiceTitanLocnNumber> LocnNumbers { get; set; }
    }
}
