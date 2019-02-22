using A1ServicesApp.Data.Entities.BusinessRules;
using A1ServicesApp.Data.Entities.ServiceMaterials;
using A1ServicesApp.Data.Entities.ServiceTitan;
using A1ServicesApp.Features.JobMaterials.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ServicesApp.Data
{
    public class A1ServicesAppDbContext : DbContext
    {
        public A1ServicesAppDbContext(DbContextOptions<A1ServicesAppDbContext> options) : base(options)
        {

        }

        public DbSet<SpecificationRule> SpecificationRules { get; set; }



        public DbSet<JobServiceMaterialLink> JobServiceMaterialLinks { get; set; }
        public DbSet<JobService> JobServices { get; set; }
        public DbSet<JobMaterial> JobMaterials { get; set; }
        public DbSet<MaterialListItem> MaterialListItems { get; set; }


        //Service Titan Entities
        public DbSet<ServiceTitanJobModel> ServiceTitanJobModel { get; set; }
        public DbSet<ServiceTitanBusinessUnitModel> ServiceTitanBusinessUnitModel { get; set; }
        public DbSet<ServiceTitanCampaignModel> ServiceTitanCampaignModel { get; set; }
        public DbSet<ServiceTitanTechgeneratedLeadSourceModel> ServiceTitanTechgeneratedLeadSourceModel { get; set; }
        public DbSet<ServiceTitanJobTypeModel> ServiceTitanJobTypeModel { get; set; }
        public DbSet<ServiceTitanCustomerModel> ServiceTitanCustomerModel { get; set; }
        public DbSet<ServiceTitanLocationModel> ServiceTitanLocationModel { get; set; }
        public DbSet<ServiceTitanTagModel> ServiceTitanTagModel { get; set; }
        public DbSet<ServiceTitanJobAssignmentModel> ServiceTitanJobAssignmentModel { get; set; }
        public DbSet<ServiceTitanEstimateModel> ServiceTitanEstimateModel { get; set; }
        public DbSet<ServiceTitanInvoiceModel> ServiceTitanInvoiceModel { get; set; }
        public DbSet<ServiceTitanEmployeeDetailedModel> ServiceTitanEmployeeDetailedModel { get; set; }
        public DbSet<ServiceTitanCallModel> ServiceTitanCallModel { get; set; }
        public DbSet<ServiceTitanCustomFieldApiModel> ServiceTitanCustomFieldApiModel { get; set; }
        public DbSet<ServiceTitanAddressModel> ServiceTitanAddressModel { get; set; }
        public DbSet<ServiceTitanContactModel> ServiceTitanContactModel { get; set; }
        public DbSet<ServiceTitanEmployeeModel> ServiceTitanEmployeeModel { get; set; }
        public DbSet<ServiceTitanEstimateItemModel> ServiceTitanEstimateItemModel { get; set; }
        public DbSet<ServiceTitanInvoiceStatusModel> ServiceTitanInvoiceStatusModel { get; set; }
        public DbSet<ServiceTitanInvoiceItemModel> ServiceTitanInvoiceItemModel { get; set; }
        public DbSet<ServiceTitanPaymentModel> ServiceTitanPaymentModel { get; set; }
        public DbSet<ServiceTitanPurchaseOrderModel> ServiceTitanPurchaseOrderModel { get; set; }
        public DbSet<ServiceTitanPurchaseOrderItemModel> ServiceTitanPurchaseOrderItemModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<SmartPlaylist>()
        }
    }
}
