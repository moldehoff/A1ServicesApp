using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.JobServices.Models
{
    public class JobServiceDto
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ServiceId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public double? MemberPrice { get; set; }
        public double? AddOnPrice { get; set; }
        public double? AddOnMemberPrice { get; set; }
        public int? Active { get; set; }
    }
}
