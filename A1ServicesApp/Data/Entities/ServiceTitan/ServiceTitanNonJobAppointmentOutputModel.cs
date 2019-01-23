using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanNonJobAppointmentOutputModel
    {
        public int? Id { get; set; }
        public ServiceTitanTechnicianDetailedModel Technician { get; set; }
        public string Start { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public ServiceTitanTimesheetCodeModel TimesheetCode { get; set; }
        public string Summary { get; set; }
        public bool? ClearDispatchBoard { get; set; }
        public bool? ClearTechnicianView { get; set; }
        public bool? RemoveTechnicianFromCapacityPlanning { get; set; }
        public bool? AllDay { get; set; }
        public bool? Active { get; set; }
        public string CreatedOn { get; set; }
        public int? CreatedById { get; set; }

    }
}
