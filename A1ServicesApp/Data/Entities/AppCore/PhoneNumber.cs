using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.AppCore
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Memo { get; set; }
        public bool Active { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
