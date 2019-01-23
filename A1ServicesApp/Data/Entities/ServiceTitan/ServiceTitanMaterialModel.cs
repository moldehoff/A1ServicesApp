using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data.Entities.ServiceTitan
{
    public class ServiceTitanMaterialModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public double? Cost { get; set; }
        public bool? Active { get; set; }
        public double? Price { get; set; }
        public double? MemberPrice { get; set; }
        public double? AddOnPrice { get; set; }
        public double? AddOnMemberPrice { get; set; }
        public double? Hours { get; set; }
        public double? Bonus { get; set; }
        public double? CommissionBonus { get; set; }
        public bool? PaysCommission { get; set; }
        public bool? PayTechSpecificBonus { get; set; }
        public bool? DisplayInAmount { get; set; }
        public bool? NoTax { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool? IsInventory { get; set; }
        public string Account { get; set; }
        public bool? Taxable { get; set; }
        public ServiceTitanMaterialVendorModel PrimaryVendor { get; set; }
        public ICollection<ServiceTitanMaterialVendorModel> OtherVendors { get; set; }
        public ICollection<ServiceTitanSkuApiCategoryModel> Categories { get; set; }
        public ICollection<ServiceTitanImageModel> Images { get; set; }
        public ICollection<ServiceTitanVideoModel> Videos { get; set; }
        public string ModifiedOn { get; set; }

    }
}
