using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanPayrollFieldModel
    {
        public object CustomFields { get; set; }
        public object TechnicianFields { get; set; }
        public object ServiceFields { get; set; }
        public object MaterialFields { get; set; }
        public object EquipmentFields { get; set; }
        public object BusinessUnitFields { get; set; }

    }
}
