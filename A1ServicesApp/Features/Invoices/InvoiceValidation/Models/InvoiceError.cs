using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Features.InvoiceValidation
{
    public class InvoiceError
    {
        public int FlaggedJobId { get; set; }
        public string FlaggedMaterialCode { get; set; }
        public int FlaggedMaterialId { get; set; }
        public string JobCompletedDate { get; set; }
        public string TechnicianName { get; set; } = "";
        public int TechnicianId { get; set; } = 0;
        public string ServiceCode { get; set; } = "";
    }
}
