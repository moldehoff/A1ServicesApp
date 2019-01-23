using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string WarrantyDescription { get; set; }
        public ICollection<ServiceTitanSkuApiCategoryModel> Categories { get; set; } = new List<ServiceTitanSkuApiCategoryModel>();
        public double? Price { get; set; }
        public double? MemberPrice { get; set; }
        public double? AddOnPrice { get; set; }
        public double? AddOnMemberPrice { get; set; }
        public bool? Taxable { get; set; }
        public string QuickbooksAccount { get; set; }
        public double? CommissionHours { get; set; }
        public double? MinimumLaborTime { get; set; }
        public bool? IsTimeAndMaterial { get; set; }
        public bool? IsLabor { get; set; }
        public ICollection<int> AddOns { get; set; } = new List<int>();
        public ICollection<int> Upgrades { get; set; } = new List<int>();
        public ICollection<ServiceTitanImageModel> Images { get; set; } = new List<ServiceTitanImageModel>();
        public ICollection<ServiceTitanVideoModel> Videos { get; set; } = new List<ServiceTitanVideoModel>();
        public ICollection<ServiceTitanServiceMaterialModel> Materials { get; set; } = new List<ServiceTitanServiceMaterialModel>();
    }


}
