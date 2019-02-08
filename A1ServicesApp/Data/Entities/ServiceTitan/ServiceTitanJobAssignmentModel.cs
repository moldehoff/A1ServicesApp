using System;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanJobAssignmentModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int? JobId { get; set; }
        public string JobNumber { get; set; }
        public ServiceTitanEmployeeModel Technician { get; set; }
        public string Team { get; set; }
        public float? Split { get; set; }
        public double? TotalDrivingHours { get; set; }
        public double? TotalWorkingHours { get; set; }
        public DateTime AssignedOn { get; set; }
        public ServiceTitanAssignedBy AssignedBy { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string PayType { get; set; }

    }
}