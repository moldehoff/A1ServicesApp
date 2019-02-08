using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanSkuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public float? SoldHours { get; set; }
        public int? GeneralLedgerAccountId { get; set; }
        public string GeneralLedgerAccountName { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
