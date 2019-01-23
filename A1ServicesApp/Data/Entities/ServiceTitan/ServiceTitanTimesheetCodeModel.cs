using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanTimesheetCodeModel
    {
        public int? Id { get; set; }
        public bool? Active { get; set; }
        public string EventName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string HourlyRate { get; set; }
        public double? CustomHourlyRate { get; set; }
        public double? RateMultiplier { get; set; }
        public string Visibility { get; set; }
        public bool? DeductCommuteTime { get; set; }
        public bool? EnableSimnpleClockInOut { get; set; }
        public bool? ExcludeAbsentEvent { get; set; }
        public ServiceTitanAddressModel Address { get; set; }
        public bool? IsAutoClockInEnabled { get; set; }
        public bool? IsDefaultShopTime { get; set; }
        public bool? CountOnJobCounter { get; set; }

    }
}
