using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanTechnicianShiftModel
    {
        public int? Id { get; set; }
        public string ShiftType { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool? Active { get; set; }
        public ServiceTitanTechnicianDetailedModel Technician { get; set; }
        public ServiceTitanTimesheetCodeModel TimesheetCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
