[33mcommit b94d3ab66db682bc7a0d7fc068fa0b1e2e346f18[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m, [m[1;31morigin/master[m[33m, [m[1;31morigin/HEAD[m[33m)[m
Author: moldehoff <michaeloldehoff@gmail.com>
Date:   Wed Feb 20 10:51:46 2019 -0700

    refactor invoice validator

[1mdiff --git a/A1ServicesApp/A1ServicesApp.csproj b/A1ServicesApp/A1ServicesApp.csproj[m
[1mindex 876c9fb..17e031e 100644[m
[1m--- a/A1ServicesApp/A1ServicesApp.csproj[m
[1m+++ b/A1ServicesApp/A1ServicesApp.csproj[m
[36m@@ -1,10 +1,9 @@[m
[31m-﻿<Project Sdk="Microsoft.NET.Sdk.Web">[m
[32m+[m[32m<Project Sdk="Microsoft.NET.Sdk.Web">[m
 [m
   <PropertyGroup>[m
     <TargetFramework>netcoreapp2.2</TargetFramework>[m
[31m-    <AspNetCoreHostingModel>OutOfProcess</AspNetCoreHostingModel>[m
[31m-    <AspNetCoreModuleName>AspNetCoreModule</AspNetCoreModuleName>[m
[31m-    <UserSecretsId>b15ae58e-e3b1-4f30-b237-a3377297f6a7</UserSecretsId>[m
[32m+[m[32m    <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>[m
[32m+[m[32m    <UserSecretsId>68d20829-8f0d-4407-a709-d2ea95201fc1</UserSecretsId>[m
   </PropertyGroup>[m
 [m
   <ItemGroup>[m
[36m@@ -21,7 +20,6 @@[m
     <PackageReference Include="Microsoft.Azure.Services.AppAuthentication" Version="1.0.3" />[m
     <PackageReference Include="Microsoft.Extensions.Configuration.AzureKeyVault" Version="2.2.0" />[m
     <PackageReference Include="OdeToCode.AddFeatureFolders" Version="2.0.3" />[m
[31m-    <PackageReference Include="System.Data.SqlClient" Version="4.6.0" />[m
   </ItemGroup>[m
 [m
   <ItemGroup>[m
[1mdiff --git a/A1ServicesApp/A1ServicesApp.csproj.user b/A1ServicesApp/A1ServicesApp.csproj.user[m
[1mindex 0083a05..b4d3f36 100644[m
[1m--- a/A1ServicesApp/A1ServicesApp.csproj.user[m
[1m+++ b/A1ServicesApp/A1ServicesApp.csproj.user[m
[36m@@ -2,7 +2,5 @@[m
 <Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">[m
   <PropertyGroup>[m
     <NameOfLastUsedPublishProfile>A1ServicesApp - Web Deploy</NameOfLastUsedPublishProfile>[m
[31m-    <ActiveDebugProfile>IIS Express</ActiveDebugProfile>[m
[31m-    <ShowAllFiles>true</ShowAllFiles>[m
   </PropertyGroup>[m
 </Project>[m
\ No newline at end of file[m
[1mdiff --git a/A1ServicesApp/Data/A1ServicesAppDbContext.cs b/A1ServicesApp/Data/A1ServicesAppDbContext.cs[m
[1mindex b7346bc..e003260 100644[m
[1m--- a/A1ServicesApp/Data/A1ServicesAppDbContext.cs[m
[1m+++ b/A1ServicesApp/Data/A1ServicesAppDbContext.cs[m
[36m@@ -1,10 +1,9 @@[m
 ﻿using A1ServicesApp.Data.Entities.ServiceMaterials;[m
[32m+[m[32musing A1ServicesApp.Data.Entities.ServiceTitan;[m
 using A1ServicesApp.Features.JobMaterials.Models;[m
[31m-using Microsoft.Azure.Services.AppAuthentication;[m
 using Microsoft.EntityFrameworkCore;[m
 using System;[m
 using System.Collections.Generic;[m
[31m-using System.Data.SqlClient;[m
 using System.Linq;[m
 using System.Text;[m
 using System.Threading.Tasks;[m
[36m@@ -15,7 +14,7 @@[m [mnamespace A1ServicesApp.Data[m
     {[m
         public A1ServicesAppDbContext(DbContextOptions<A1ServicesAppDbContext> options) : base(options)[m
         {[m
[31m-            [m
[32m+[m
         }[m
 [m
         public DbSet<JobServiceMaterialLink> JobServiceMaterialLinks { get; set; }[m
[36m@@ -24,9 +23,31 @@[m [mnamespace A1ServicesApp.Data[m
         public DbSet<MaterialListItem> MaterialListItems { get; set; }[m
 [m
 [m
[31m-        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)[m
[31m-        {[m
[31m-            [m
[31m-        }[m
[32m+[m[32m        //Service Titan Entities[m
[32m+[m[32m        public DbSet<ServiceTitanJobModel> ServiceTitanJobModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanBusinessUnitModel> ServiceTitanBusinessUnitModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanCampaignModel> ServiceTitanCampaignModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanTechgeneratedLeadSourceModel> ServiceTitanTechgeneratedLeadSourceModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanJobTypeModel> ServiceTitanJobTypeModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanCustomerModel> ServiceTitanCustomerModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanLocationModel> ServiceTitanLocationModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanTagModel> ServiceTitanTagModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanJobAssignmentModel> ServiceTitanJobAssignmentModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanEstimateModel> ServiceTitanEstimateModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanInvoiceModel> ServiceTitanInvoiceModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanEmployeeDetailedModel> ServiceTitanEmployeeDetailedModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanCallModel> ServiceTitanCallModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanCustomFieldApiModel> ServiceTitanCustomFieldApiModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanAddressModel> ServiceTitanAddressModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanContactModel> ServiceTitanContactModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanEmployeeModel> ServiceTitanEmployeeModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanEstimateItemModel> ServiceTitanEstimateItemModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanInvoiceStatusModel> ServiceTitanInvoiceStatusModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanInvoiceItemModel> ServiceTitanInvoiceItemModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanPaymentModel> ServiceTitanPaymentModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanPurchaseOrderModel> ServiceTitanPurchaseOrderModel { get; set; }[m
[32m+[m[32m        public DbSet<ServiceTitanPurchaseOrderItemModel> ServiceTitanPurchaseOrderItemModel { get; set; }[m
[32m+[m
[32m+[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Data/Entities/ServiceMaterials/MaterialList.cs b/A1ServicesApp/Data/Entities/ServiceMaterials/MaterialList.cs[m
[1mindex 32b3cdf..edef89c 100644[m
[1m--- a/A1ServicesApp/Data/Entities/ServiceMaterials/MaterialList.cs[m
[1m+++ b/A1ServicesApp/Data/Entities/ServiceMaterials/MaterialList.cs[m
[36m@@ -24,7 +24,7 @@[m [mnamespace A1ServicesApp.Data.Entities.ServiceMaterials[m
         }[m
 [m
         public int Id { get; set; }[m
[31m-        public string Type { get; set; } // "All" Materials Requuired or "Any" Material Required [m
[32m+[m[32m        public string Type { get; set; } // "All" Materials Required or "Any" Material Required[m[41m [m
         public string Name { get; set; }[m
 [m
         public ICollection<MaterialListItem> MaterialListItems { get; set; } = new List<MaterialListItem>();[m
[1mdiff --git a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanCustomFieldApiModel.cs b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanCustomFieldApiModel.cs[m
[1mindex 1b6a812..eee5576 100644[m
[1m--- a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanCustomFieldApiModel.cs[m
[1m+++ b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanCustomFieldApiModel.cs[m
[36m@@ -8,6 +8,7 @@[m [mnamespace A1ServicesApp.Data.Entities.ServiceTitan[m
 {[m
     public class ServiceTitanCustomFieldApiModel[m
     {[m
[32m+[m[32m        public int? Id { get; set; }[m
         public int TypeId { get; set; }[m
         public string Name { get; set; }[m
         public string Value { get; set; }[m
[1mdiff --git a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanEstimateItemModel.cs b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanEstimateItemModel.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..76a9ca2[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanEstimateItemModel.cs[m
[36m@@ -0,0 +1,27 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Data.Entities.ServiceTitan[m
[32m+[m[32m{[m
[32m+[m[32m    public class ServiceTitanEstimateItemModel[m
[32m+[m[32m    {[m
[32m+[m[32m        public int? Id { get; set; }[m
[32m+[m[32m        public ServiceTitanSkuModel Sku { get; set; }[m
[32m+[m[32m        public string SkuAccount { get; set; }[m
[32m+[m[32m        public string Type { get; set; }[m
[32m+[m[32m        public string Description { get; set; }[m
[32m+[m[32m        public string MembershipTypeId { get; set; }[m
[32m+[m[32m        public float? qty { get; set; }[m
[32m+[m[32m        public float? UnitRate { get; set; }[m
[32m+[m[32m        public float? Total { get; set; }[m
[32m+[m[32m        public float? Tax { get; set; }[m
[32m+[m[32m        public float? Subtotal { get; set; }[m
[32m+[m[32m        public string ItemGroupName { get; set; }[m
[32m+[m[32m        public string ItemGroupRootId { get; set; }[m
[32m+[m[32m        public string ModifiedOn { get; set; }[m
[32m+[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanImageModel.cs b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanImageModel.cs[m
[1mindex a62d4d1..190fa6b 100644[m
[1m--- a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanImageModel.cs[m
[1m+++ b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanImageModel.cs[m
[36m@@ -8,6 +8,7 @@[m [mnamespace A1ServicesApp.Data.Entities.ServiceTitan[m
 {[m
     public class ServiceTitanImageModel[m
     {[m
[32m+[m[32m        public int? Id { get; set; }[m
         public string FileName { get; set; }[m
 [m
     }[m
[1mdiff --git a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanVideoModel.cs b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanVideoModel.cs[m
[1mindex 2c4b529..19b3718 100644[m
[1m--- a/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanVideoModel.cs[m
[1m+++ b/A1ServicesApp/Data/Entities/ServiceTitan/ServiceTitanVideoModel.cs[m
[36m@@ -8,6 +8,7 @@[m [mnamespace A1ServicesApp.Data.Entities.ServiceTitan[m
 {[m
     public class ServiceTitanVideoModel[m
     {[m
[32m+[m[32m        public int? Id { get; set; }[m
         public string Url { get; set; }[m
 [m
     }[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/AllMaterialValidator.cs b/A1ServicesApp/Features/InvoiceValidation/AllMaterialValidator.cs[m
[1mdeleted file mode 100644[m
[1mindex a283d41..0000000[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/AllMaterialValidator.cs[m
[1m+++ /dev/null[m
[36m@@ -1,19 +0,0 @@[m
[31m-﻿using A1ServicesApp.Features.InvoiceValidation.Models;[m
[31m-using System;[m
[31m-using System.Collections.Generic;[m
[31m-using System.Linq;[m
[31m-using System.Text;[m
[31m-using System.Threading.Tasks;[m
[31m-[m
[31m-namespace A1ServicesApp.Features.InvoiceValidation[m
[31m-{[m
[31m-    public class AllMaterialValidator : IMaterialValidator[m
[31m-    {[m
[31m-        public IValidationState State { get; set; } = new Valid();[m
[31m-[m
[31m-        public IValidationState RunValidation()[m
[31m-        {[m
[31m-            return new Valid();[m
[31m-        }[m
[31m-    }[m
[31m-}[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/AnyMaterialValidator.cs b/A1ServicesApp/Features/InvoiceValidation/AnyMaterialValidator.cs[m
[1mdeleted file mode 100644[m
[1mindex 27084a8..0000000[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/AnyMaterialValidator.cs[m
[1m+++ /dev/null[m
[36m@@ -1,65 +0,0 @@[m
[31m-﻿using System;[m
[31m-using System.Collections.Generic;[m
[31m-using System.Linq;[m
[31m-using System.Text;[m
[31m-using System.Threading.Tasks;[m
[31m-using A1ServicesApp.Data.Entities.ServiceMaterials;[m
[31m-using A1ServicesApp.Data.Entities.ServiceTitan;[m
[31m-using A1ServicesApp.Features.InvoiceValidation.Models;[m
[31m-using Microsoft.EntityFrameworkCore;[m
[31m-[m
[31m-namespace A1ServicesApp.Features.InvoiceValidation[m
[31m-{[m
[31m-    public class AnyMaterialValidator : IMaterialValidator[m
[31m-    {[m
[31m-        public IValidationState State { get; set; } = new Valid();[m
[31m-        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();[m
[31m-[m
[31m-[m
[31m-        public IValidationState RunValidation(List<ServiceTitanInvoiceItemModel> materialInvoiceItems)[m
[31m-        {[m
[31m-            return (IValidationState) new Valid();[m
[31m-[m
[31m-            //if (ml.Type == "Any") //(!materialInvoiceItems.Any(m => mlItems.Any(i => i.MaterialId == m.Sku.Id))))[m
[31m-            //{[m
[31m-            //    var anyMatch = false;[m
[31m-            //    foreach (var listItem in ml.MaterialListItems.AsQueryable().Include(m => m.JobMaterial).ToList())[m
[31m-            //    {[m
[31m-            //        if (materialInvoiceItems.Any(m => m.Sku.Id == listItem.MaterialId))[m
[31m-            //        {[m
[31m-            //            anyMatch = true;[m
[31m-            //        }[m
[31m-            //    }[m
[31m-[m
[31m-            //    if (anyMatch == false)[m
[31m-            //    {[m
[31m-            //        var jobAssignment = job.JobAssignments.AsQueryable().Include(j => j.Technician).Where(j => j.Active == true).FirstOrDefault();[m
[31m-[m
[31m-            //        result.Add(new FlaggedJobServiceMaterialsDto()[m
[31m-            //        {[m
[31m-            //            FlaggedJobId = Convert.ToInt32(job.JobNumber),[m
[31m-            //            FlaggedMaterialCode = ml.Name,[m
[31m-            //            JobCompletedDate = job.CompletedOn,[m
[31m-            //            TechnicianName = jobAssignment.Technician.Name,[m
[31m-            //            TechnicianId = jobAssignment.Technician.Id[m
[31m-            //            //FlaggedJob = job,[m
[31m-            //            //FlaggedLink = _mapper.Map<JobServiceMaterialLinkDto>(link),[m
[31m-            //            //FlaggedMaterialList = ml,[m
[31m-            //            //FlaggedMaterialListItem = listItem[m
[31m-            //        });[m
[31m-            //        link = null;[m
[31m-            //        goto outer_loop;[m
[31m-            //    }[m
[31m-[m
[31m-[m
[31m-[m
[31m-[m
[31m-[m
[31m-        }[m
[31m-[m
[31m-        public IValidationState RunValidation()[m
[31m-        {[m
[31m-            return new Valid();[m
[31m-        }[m
[31m-    }[m
[31m-}[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/InvoiceValidator.cs b/A1ServicesApp/Features/InvoiceValidation/InvoiceValidator.cs[m
[1mdeleted file mode 100644[m
[1mindex 95ddad2..0000000[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/InvoiceValidator.cs[m
[1m+++ /dev/null[m
[36m@@ -1,36 +0,0 @@[m
[31m-﻿using A1ServicesApp.Data;[m
[31m-using A1ServicesApp.Data.Entities.ServiceTitan;[m
[31m-using A1ServicesApp.Features.InvoiceValidation.Models;[m
[31m-using System;[m
[31m-using System.Collections.Generic;[m
[31m-using System.Linq;[m
[31m-using System.Text;[m
[31m-using System.Threading.Tasks;[m
[31m-[m
[31m-namespace A1ServicesApp.Features.InvoiceValidation[m
[31m-{[m
[31m-    public class InvoiceValidator[m
[31m-    {[m
[31m-        public ServiceTitanJobModel Job { get; set; }[m
[31m-        public ServiceTitanInvoiceModel Invoice { get; set; }[m
[31m-        public IInvoiceValidationState ValidationState { get; set; }[m
[31m-[m
[31m-        public ICollection<ServiceTitanInvoiceItemModel> ServiceItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();[m
[31m-        public ICollection<ServiceTitanInvoiceItemModel> MaterialItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();[m
[31m-[m
[31m-        public ICollection<IMaterialValidator> MaterialValidators { get; set; } = new List<IMaterialValidator>();[m
[31m-[m
[31m-        public InvoiceValidator(ServiceTitanJobModel jobModel)[m
[31m-        {[m
[31m-            var materialValidatorFactory = new MaterialValidatorFactory();[m
[31m-[m
[31m-            Job = jobModel;[m
[31m-            Invoice = jobModel.Invoice;[m
[31m-            ValidationState = new ValidInvoice();[m
[31m-            ServiceItems = jobModel.Invoice.Items.Where(i => i.Sku.Type == "Service").ToList();[m
[31m-            MaterialItems = jobModel.Invoice.Items.Where(i => i.Sku.Type == "Material").ToList();[m
[31m-            MaterialValidators = materialValidatorFactory.CreateMaterialValidators(MaterialItems.ToList());[m
[31m-[m
[31m-        }[m
[31m-    }[m
[31m-}[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/Commands/ValidateJobInvoiceCommand.cs b/A1ServicesApp/Features/Invoices/Commands/ValidateJobInvoiceCommand.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..216a51b[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/Commands/ValidateJobInvoiceCommand.cs[m
[36m@@ -0,0 +1,17 @@[m
[32m+[m[32m﻿using A1ServicesApp.Data.Entities.ServiceTitan;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation;[m
[32m+[m[32musing MediatR;[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.Invoices.Commands[m
[32m+[m[32m{[m
[32m+[m[32m    public class ValidateJobInvoiceCommand : IRequest<List<InvoiceError>>[m
[32m+[m[32m    {[m
[32m+[m[32m        public ServiceTitanJobModel Job { get; set; }[m
[32m+[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/Commands/ValidateJobInvoiceCommandHandler.cs b/A1ServicesApp/Features/Invoices/Commands/ValidateJobInvoiceCommandHandler.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..b50ccd1[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/Commands/ValidateJobInvoiceCommandHandler.cs[m
[36m@@ -0,0 +1,38 @@[m
[32m+[m[32m﻿using A1ServicesApp.Data;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation;[m
[32m+[m[32musing MediatR;[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.Invoices.Commands[m
[32m+[m[32m{[m
[32m+[m[32m    public class ValidateJobInvoiceCommandHandler : IRequestHandler<ValidateJobInvoiceCommand, List<InvoiceError>>[m
[32m+[m[32m    {[m
[32m+[m[32m        private A1ServicesAppDbContext _ctx;[m
[32m+[m
[32m+[m[32m        public ValidateJobInvoiceCommandHandler(A1ServicesAppDbContext ctx)[m
[32m+[m[32m        {[m
[32m+[m[32m            _ctx = ctx;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public Task<List<InvoiceError>> Handle(ValidateJobInvoiceCommand request, CancellationToken cancellationToken)[m
[32m+[m[32m        {[m
[32m+[m[32m            var result = new List<InvoiceError>();[m
[32m+[m
[32m+[m[32m            var invoiceValidator = new InvoiceValidator(request.Job, _ctx);[m
[32m+[m
[32m+[m[32m            if (invoiceValidator.MaterialValidators.Any())[m
[32m+[m[32m            {[m
[32m+[m[32m                invoiceValidator.RunMaterialValidators();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            result.AddRange(invoiceValidator.InvoiceErrors);[m
[32m+[m
[32m+[m[32m            return Task.FromResult<List<InvoiceError>>(result);[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/InvoiceController.cs b/A1ServicesApp/Features/Invoices/InvoiceController.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..651ae9f[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceController.cs[m
[36m@@ -0,0 +1,64 @@[m
[32m+[m[32m﻿using A1ServicesApp.Data;[m
[32m+[m[32musing A1ServicesApp.Data.Constants.ServiceTitanApiFilters;[m
[32m+[m[32musing A1ServicesApp.Features.Jobs.Models;[m
[32m+[m[32musing A1ServicesApp.Features.Jobs.Queries;[m
[32m+[m[32musing MediatR;[m
[32m+[m[32musing Microsoft.AspNetCore.Mvc;[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.InvoiceValidation[m
[32m+[m[32m{[m
[32m+[m[32m    [Route("api/[controller]")][m
[32m+[m[32m    public class InvoiceController : Controller[m
[32m+[m[32m    {[m
[32m+[m[32m        private IMediator _mediator;[m
[32m+[m[32m        private A1ServicesAppDbContext _ctx;[m
[32m+[m
[32m+[m[32m        public InvoiceController(IMediator mediator, A1ServicesAppDbContext ctx)[m
[32m+[m[32m        {[m
[32m+[m[32m            _mediator = mediator;[m
[32m+[m[32m            _ctx = ctx;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        [HttpGet("validate")][m
[32m+[m[32m        public IActionResult RunInvoiceValidators()[m
[32m+[m[32m        {[m
[32m+[m[32m            var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);[m
[32m+[m
[32m+[m[32m            var queryStringModel = new GetJobsQueryStringModel()[m
[32m+[m[32m            {[m
[32m+[m[32m                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",[m
[32m+[m[32m                CompletedBefore = new FilterCompletedBefore() { FilterValue = todaysDate.AddDays(1) },[m
[32m+[m[32m                CompletedAfter = new FilterCompletedAfter() { FilterValue = todaysDate.AddDays(-1) }[m
[32m+[m[32m            };[m
[32m+[m
[32m+[m[32m            var getJobsFromST = _mediator.Send(new GetJobsFromServiceTitanQuery(queryStringModel)).Result;[m
[32m+[m
[32m+[m[32m            var invoiceValidators = new List<InvoiceValidator>();[m
[32m+[m[32m            var invoicesWithErrors = new List<InvoiceValidator>();[m
[32m+[m[32m            var errorReports = new List<InvoiceError>();[m
[32m+[m[32m            foreach (var job in getJobsFromST.ApiResults)[m
[32m+[m[32m            {[m
[32m+[m[32m                invoiceValidators.Add(new InvoiceValidator(job, _ctx));[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[41m            [m
[32m+[m
[32m+[m[32m            foreach (var i in invoiceValidators)[m
[32m+[m[32m            {[m
[32m+[m[32m                i.RunMaterialValidators();[m
[32m+[m[32m                if (i.InvoiceErrors.Count > 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    invoicesWithErrors.Add(i);[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m[32m            foreach (var i in invoicesWithErrors)[m
[32m+[m[32m            {[m
[32m+[m[32m                errorReports.AddRange(i.InvoiceErrors);[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return Ok(errorReports);[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/InvoiceValidation/InvoiceValidator.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/InvoiceValidator.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..b515c08[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/InvoiceValidator.cs[m
[36m@@ -0,0 +1,73 @@[m
[32m+[m[32m﻿using A1ServicesApp.Data;[m
[32m+[m[32musing A1ServicesApp.Data.Entities.ServiceTitan;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation.Models;[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.InvoiceValidation[m
[32m+[m[32m{[m
[32m+[m[32m    public class InvoiceValidator[m
[32m+[m[32m    {[m
[32m+[m[32m        private A1ServicesAppDbContext _ctx;[m
[32m+[m[32m        private TaskMaterialValidatorFactory _materialValidatorFactory;[m
[32m+[m
[32m+[m[32m        public ServiceTitanJobModel Job { get; set; }[m
[32m+[m[32m        public ServiceTitanInvoiceModel Invoice { get; set; }[m
[32m+[m[32m        public IInvoiceValidationState ValidationState { get; set; } = new ValidInvoice();[m
[32m+[m
[32m+[m[32m        public ICollection<ServiceTitanInvoiceItemModel> ServiceItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();[m
[32m+[m[32m        public ICollection<ServiceTitanInvoiceItemModel> MaterialItems { get; set; } = new List<ServiceTitanInvoiceItemModel>();[m
[32m+[m
[32m+[m[32m        public ICollection<IMaterialValidator> MaterialValidators { get; set; } = new List<IMaterialValidator>();[m
[32m+[m
[32m+[m[32m        public ICollection<InvoiceError> InvoiceErrors { get; set; } = new List<InvoiceError>();[m
[32m+[m
[32m+[m[32m        public InvoiceValidator(ServiceTitanJobModel jobModel, A1ServicesAppDbContext ctx)[m
[32m+[m[32m        {[m
[32m+[m[32m            _ctx = ctx;[m
[32m+[m[32m            var materialValidatorFactory = new TaskMaterialValidatorFactory(_ctx);[m
[32m+[m[32m            _materialValidatorFactory = materialValidatorFactory;[m
[32m+[m
[32m+[m[32m            Job = jobModel;[m
[32m+[m[32m            Invoice = jobModel.Invoice;[m
[32m+[m[32m            ValidationState = new ValidInvoice();[m
[32m+[m[32m            ServiceItems = jobModel.Invoice.Items.Where(i => i.Active == true).Where(i=> i.Sku.Type == "Service").ToList();[m
[32m+[m[32m            MaterialItems = jobModel.Invoice.Items.Where(i => i.Active == true).Where(i=>i.Sku.Type == "Material").ToList();[m
[32m+[m[32m            MaterialValidators = CreateValidators();[m
[32m+[m
[32m+[m[41m            [m
[32m+[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public InvoiceValidator()[m
[32m+[m[32m        {[m
[32m+[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public List<IMaterialValidator> CreateValidators()[m
[32m+[m[32m        {[m
[32m+[m[32m            var materialValidatorList = new List<IMaterialValidator>();[m
[32m+[m[32m            materialValidatorList.AddRange(_materialValidatorFactory.CreateMaterialValidators(ServiceItems.ToList()));[m
[32m+[m
[32m+[m[32m            return materialValidatorList;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public void RunMaterialValidators()[m
[32m+[m[32m        {[m
[32m+[m[32m            Parallel.ForEach(MaterialValidators, m => m.RunValidation(this));[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public void SetInvoiceStateInvalid()[m
[32m+[m[32m        {[m
[32m+[m[32m            this.ValidationState.SetInvalid();[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public void SetInvoiceStateValid()[m
[32m+[m[32m        {[m
[32m+[m[32m            this.ValidationState.SetValid();[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/InvoiceValidation/Models/InvoiceError.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/Models/InvoiceError.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..0c8c068[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/Models/InvoiceError.cs[m
[36m@@ -0,0 +1,19 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.InvoiceValidation[m
[32m+[m[32m{[m
[32m+[m[32m    public class InvoiceError[m
[32m+[m[32m    {[m
[32m+[m[32m        public int FlaggedJobId { get; set; }[m
[32m+[m[32m        public string FlaggedMaterialCode { get; set; }[m
[32m+[m[32m        public int FlaggedMaterialId { get; set; }[m
[32m+[m[32m        public string JobCompletedDate { get; set; }[m
[32m+[m[32m        public string TechnicianName { get; set; } = "";[m
[32m+[m[32m        public int TechnicianId { get; set; } = 0;[m
[32m+[m[32m        public string ServiceCode { get; set; } = "";[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/IInvoiceValidationState.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/State/IInvoiceValidationState.cs[m
[1msimilarity index 72%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/IInvoiceValidationState.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/State/IInvoiceValidationState.cs[m
[1mindex a1344c2..9cefdce 100644[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/IInvoiceValidationState.cs[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/State/IInvoiceValidationState.cs[m
[36m@@ -8,6 +8,7 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
 {[m
     public interface IInvoiceValidationState[m
     {[m
[31m-        [m
[32m+[m[32m        IInvoiceValidationState SetInvalid();[m
[32m+[m[32m        IInvoiceValidationState SetValid();[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/InvalidInvoice.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/State/InvalidInvoice.cs[m
[1msimilarity index 66%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/InvalidInvoice.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/State/InvalidInvoice.cs[m
[1mindex baff8c2..95dc791 100644[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/InvalidInvoice.cs[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/State/InvalidInvoice.cs[m
[36m@@ -8,6 +8,8 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
 {[m
     public class InvalidInvoice : IInvoiceValidationState[m
     {[m
[31m-        [m
[32m+[m[32m        public IInvoiceValidationState SetInvalid() => this;[m
[32m+[m
[32m+[m[32m        public IInvoiceValidationState SetValid() => this;[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/ValidInvoice.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/State/ValidInvoice.cs[m
[1msimilarity index 64%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/ValidInvoice.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/State/ValidInvoice.cs[m
[1mindex 636f237..8d64679 100644[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/ValidInvoice.cs[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/State/ValidInvoice.cs[m
[36m@@ -8,6 +8,8 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
 {[m
     public class ValidInvoice : IInvoiceValidationState[m
     {[m
[32m+[m[32m        public IInvoiceValidationState SetInvalid() => new InvalidInvoice();[m
         [m
[32m+[m[32m        public IInvoiceValidationState SetValid() => this;[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/AllMaterialValidator.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/AllMaterialValidator.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..0ec68cd[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/AllMaterialValidator.cs[m
[36m@@ -0,0 +1,52 @@[m
[32m+[m[32m﻿using A1ServicesApp.Data.Entities.ServiceMaterials;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation.Models;[m
[32m+[m[32musing Microsoft.EntityFrameworkCore;[m
[32m+[m[32musing System;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Text;[m
[32m+[m[32musing System.Threading.Tasks;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.InvoiceValidation[m
[32m+[m[32m{[m
[32m+[m[32m    public class AllMaterialValidator : IMaterialValidator[m
[32m+[m[32m    {[m
[32m+[m[32m        public IValidationState State { get; set; } = new Valid();[m
[32m+[m[32m        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();[m
[32m+[m[32m        public int? ServiceId { get; set; }[m
[32m+[m[32m        public string ServiceCode { get; set; }[m
[32m+[m
[32m+[m[32m        public void RunValidation(InvoiceValidator invoiceValidator)[m
[32m+[m[32m        {[m
[32m+[m[32m            var _materialLists = MaterialLists;[m
[32m+[m[32m            var _materialInvoiceItems = invoiceValidator.MaterialItems;[m
[32m+[m
[32m+[m[32m            foreach (var ml in _materialLists)[m
[32m+[m[32m            {[m
[32m+[m[32m                foreach (var listItem in ml.MaterialListItems.AsQueryable().Include(m => m.JobMaterial).ThenInclude(jm=>jm.MaterialId).ToList())[m
[32m+[m[32m                {[m
[32m+[m[32m                    if (!_materialInvoiceItems.Any(m => m.Sku.Id == listItem.MaterialId))[m
[32m+[m[32m                    {[m
[32m+[m[32m                        this.State = new Invalid();[m
[32m+[m[32m                        invoiceValidator.SetInvoiceStateInvalid();[m
[32m+[m[32m                        invoiceValidator.InvoiceErrors.Add(new InvoiceError()[m
[32m+[m[32m                        {[m
[32m+[m[32m                            FlaggedJobId = invoiceValidator.Job.Id,[m
[32m+[m[32m                            ServiceCode = ServiceCode,[m
[32m+[m[32m                            FlaggedMaterialCode = listItem.JobMaterial.Code,[m
[32m+[m[32m                            FlaggedMaterialId = listItem.JobMaterial.MaterialId,[m
[32m+[m[32m                            JobCompletedDate = invoiceValidator.Job.CompletedOn,[m
[32m+[m[32m                            TechnicianName = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Name).FirstOrDefault().ToString(),[m
[32m+[m[32m                            TechnicianId = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Id).FirstOrDefault()[m
[32m+[m[32m                        });[m
[32m+[m[32m                        continue;[m
[32m+[m[41m                        [m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[41m            [m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/AnyMaterialValidator.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/AnyMaterialValidator.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..a3514da[m
[1m--- /dev/null[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/AnyMaterialValidator.cs[m
[36m@@ -0,0 +1,67 @@[m
[32m+[m[32m﻿using A1ServicesApp.Data.Entities.ServiceMaterials;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation.Models;[m
[32m+[m[32musing Microsoft.EntityFrameworkCore;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m[32musing System.Linq;[m
[32m+[m
[32m+[m[32mnamespace A1ServicesApp.Features.InvoiceValidation[m
[32m+[m[32m{[m
[32m+[m[32m    public class AnyMaterialValidator : IMaterialValidator[m
[32m+[m[32m    {[m
[32m+[m[32m        public AnyMaterialValidator()[m
[32m+[m[32m        {[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public IValidationState State { get; set; } = new Valid();[m
[32m+[m[32m        public ICollection<MaterialList> MaterialLists { get; set; } = new List<MaterialList>();[m
[32m+[m[32m        public int? ServiceId { get; set; }[m
[32m+[m[32m        public string ServiceCode { get; set; }[m
[32m+[m
[32m+[m
[32m+[m[32m        public void RunValidation(InvoiceValidator invoiceValidator)[m
[32m+[m[32m        {[m
[32m+[m[32m            var _materialLists = MaterialLists;[m
[32m+[m[32m            var _materialInvoiceItems = invoiceValidator.MaterialItems;[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m            foreach (var list in _materialLists.AsQueryable().Include(ml => ml.MaterialListItems).ThenInclude(mli => mli.JobMaterial).ToList())[m
[32m+[m[32m            {[m
[32m+[m[32m                var anyMatch = false;[m
[32m+[m[32m                string flaggedMaterialCode = list.Name.Contains(" - links") ? list.Name.Remove(list.Name.Length - 8) : list.Name;[m
[32m+[m[41m                [m
[32m+[m
[32m+[m[32m                foreach (var item in list.MaterialListItems)[m
[32m+[m[32m                {[m
[32m+[m[32m                    if (_materialInvoiceItems.Any(m => m.Sku.Id == item.MaterialId))[m
[32m+[m[32m                    {[m
[32m+[m[32m                        anyMatch = true;[m
[32m+[m
[32m+[m[32m                    }[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                if (!anyMatch)[m
[32m+[m[32m                {[m
[32m+[m[32m                    this.State = new Invalid();[m
[32m+[m[32m                    invoiceValidator.SetInvoiceStateInvalid();[m
[32m+[m[32m                    invoiceValidator.InvoiceErrors.Add(new InvoiceError()[m
[32m+[m[32m                    {[m
[32m+[m[32m                        FlaggedJobId = invoiceValidator.Job.Id,[m
[32m+[m[32m                        ServiceCode = ServiceCode,[m
[32m+[m[32m                        FlaggedMaterialCode = flaggedMaterialCode,[m
[32m+[m[32m                        FlaggedMaterialId = 0,[m
[32m+[m[32m                        JobCompletedDate = invoiceValidator.Job.CompletedOn,[m
[32m+[m[32m                        TechnicianName = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Name).FirstOrDefault().ToString(),[m
[32m+[m[32m                        TechnicianId = invoiceValidator.Job.JobAssignments.Where(j => j.Active == true).Select(ja => ja.Technician.Id).FirstOrDefault()[m
[32m+[m[32m                    });[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m}[m
[32m+[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/IMaterialValidator.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/IMaterialValidator.cs[m
[1msimilarity index 85%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/IMaterialValidator.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/IMaterialValidator.cs[m
[1mindex 400a35d..07e891d 100644[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/IMaterialValidator.cs[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/IMaterialValidator.cs[m
[36m@@ -11,6 +11,6 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
     public interface IMaterialValidator[m
     {[m
         IValidationState State { get; set; }[m
[31m-        IValidationState RunValidation();[m
[32m+[m[32m        void RunValidation(InvoiceValidator invoiceValidator);[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/Models/IValidationState.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/State/IValidationState.cs[m
[1msimilarity index 100%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/Models/IValidationState.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/State/IValidationState.cs[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/Models/Invalid.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/State/Invalid.cs[m
[1msimilarity index 100%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/Models/Invalid.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/State/Invalid.cs[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/Models/Valid.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/State/Valid.cs[m
[1msimilarity index 100%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/Models/Valid.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/State/Valid.cs[m
[1mdiff --git a/A1ServicesApp/Features/InvoiceValidation/MaterialValidatorFactory.cs b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/TaskMaterialValidatorFactory.cs[m
[1msimilarity index 62%[m
[1mrename from A1ServicesApp/Features/InvoiceValidation/MaterialValidatorFactory.cs[m
[1mrename to A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/TaskMaterialValidatorFactory.cs[m
[1mindex 36ca1e6..9f31965 100644[m
[1m--- a/A1ServicesApp/Features/InvoiceValidation/MaterialValidatorFactory.cs[m
[1m+++ b/A1ServicesApp/Features/Invoices/InvoiceValidation/TaskMaterialValidators/TaskMaterialValidatorFactory.cs[m
[36m@@ -1,6 +1,8 @@[m
 ﻿using A1ServicesApp.Data;[m
 using A1ServicesApp.Data.Entities.ServiceMaterials;[m
 using A1ServicesApp.Data.Entities.ServiceTitan;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation.Models;[m
[32m+[m[32musing Microsoft.EntityFrameworkCore;[m
 using System;[m
 using System.Collections.Generic;[m
 using System.Linq;[m
[36m@@ -9,26 +11,26 @@[m [musing System.Threading.Tasks;[m
 [m
 namespace A1ServicesApp.Features.InvoiceValidation[m
 {[m
[31m-    public class MaterialValidatorFactory[m
[32m+[m[32m    public class TaskMaterialValidatorFactory[m
     {[m
         private A1ServicesAppDbContext _ctx;[m
 [m
[31m-        public MaterialValidatorFactory(A1ServicesAppDbContext ctx)[m
[32m+[m[32m        public TaskMaterialValidatorFactory(A1ServicesAppDbContext ctx)[m
         {[m
             _ctx = ctx;[m
         }[m
[31m-        public MaterialValidatorFactory()[m
[32m+[m[32m        public TaskMaterialValidatorFactory()[m
         {[m
 [m
         }[m
 [m
[31m-        public List<IMaterialValidator> CreateMaterialValidators(List<ServiceTitanInvoiceItemModel> items)[m
[32m+[m[32m        public List<IMaterialValidator> CreateMaterialValidators(List<ServiceTitanInvoiceItemModel> serviceItems)[m
         {[m
             var validators = new List<IMaterialValidator>();[m
             var jobMatLinks = new List<JobServiceMaterialLink>();[m
[31m-            var links = _ctx.JobServiceMaterialLinks.ToList();[m
[32m+[m[32m            var links = _ctx.JobServiceMaterialLinks.Include(j=>j.MaterialLists).ThenInclude(ml=>ml.MaterialListItems).ThenInclude(mli=>mli.JobMaterial).ToList();[m
 [m
[31m-            foreach (var item in items)[m
[32m+[m[32m            foreach (var item in serviceItems)[m
             {[m
                 jobMatLinks.AddRange(links.Where(l => l.ServiceId == item.Sku.Id));[m
             }[m
[36m@@ -39,11 +41,11 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
                 {[m
                     if (l.Type == "Any")[m
                     {[m
[31m-                        validators.Add(ConvertToAnyMaterialValidators(l));[m
[32m+[m[32m                        validators.Add(ConvertToAnyMaterialValidators(l, j));[m
                     }[m
                     else if (l.Type == "All")[m
                     {[m
[31m-                        validators.Add(ConvertToAllMaterialValidators(l));[m
[32m+[m[32m                        validators.Add(ConvertToAllMaterialValidators(l, j));[m
                     }[m
                 }[m
             }[m
[36m@@ -51,10 +53,13 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
             return validators;[m
         }[m
 [m
[31m-        private IMaterialValidator ConvertToAnyMaterialValidators(MaterialList list)[m
[32m+[m[32m        private IMaterialValidator ConvertToAnyMaterialValidators(MaterialList list, JobServiceMaterialLink link)[m
         {[m
             var validator = (IMaterialValidator) new AnyMaterialValidator()[m
             {[m
[32m+[m[32m                ServiceCode = link.ServiceCode,[m
[32m+[m[32m                ServiceId = link.ServiceId,[m
[32m+[m[32m                State = new Valid(),[m
                 MaterialLists = new List<MaterialList>()[m
                 {[m
                     new MaterialList(list)[m
[36m@@ -64,9 +69,18 @@[m [mnamespace A1ServicesApp.Features.InvoiceValidation[m
             return validator;[m
         }[m
 [m
[31m-        private IMaterialValidator ConvertToAllMaterialValidators(MaterialList list)[m
[32m+[m[32m        private IMaterialValidator ConvertToAllMaterialValidators(MaterialList list, JobServiceMaterialLink link)[m
         {[m
[31m-            var validator = (IMaterialValidator) new AllMaterialValidator();[m
[32m+[m[32m            var validator = (IMaterialValidator) new AllMaterialValidator()[m
[32m+[m[32m            {[m
[32m+[m[32m                ServiceCode = link.ServiceCode,[m
[32m+[m[32m                ServiceId = link.ServiceId,[m
[32m+[m[32m                State = new Valid(),[m
[32m+[m[32m                MaterialLists = new List<MaterialList>()[m
[32m+[m[32m                {[m
[32m+[m[32m                    new MaterialList(list)[m
[32m+[m[32m                }[m
[32m+[m[32m            };[m
 [m
             return validator;[m
         }[m
[1mdiff --git a/A1ServicesApp/Features/JobServiceMaterialLinks/Models/FlaggedJobServiceMaterialsDto.cs b/A1ServicesApp/Features/JobServiceMaterialLinks/Models/FlaggedJobServiceMaterialsDto.cs[m
[1mindex 9e067bd..8ec739e 100644[m
[1m--- a/A1ServicesApp/Features/JobServiceMaterialLinks/Models/FlaggedJobServiceMaterialsDto.cs[m
[1m+++ b/A1ServicesApp/Features/JobServiceMaterialLinks/Models/FlaggedJobServiceMaterialsDto.cs[m
[36m@@ -17,6 +17,8 @@[m [mnamespace A1ServicesApp.Features.JobServiceMaterialLinks.Models[m
         public string JobCompletedDate { get; set; }[m
         public string TechnicianName { get; set; }[m
         public int TechnicianId { get; set; }[m
[32m+[m[32m        public string ServiceCode { get; set; }[m
[32m+[m
 [m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/JobServiceMaterialLinks/Queries/FindJobsWithMismatchedJobMaterialsQueryHandler.cs b/A1ServicesApp/Features/JobServiceMaterialLinks/Queries/FindJobsWithMismatchedJobMaterialsQueryHandler.cs[m
[1mindex 324676e..dd459da 100644[m
[1m--- a/A1ServicesApp/Features/JobServiceMaterialLinks/Queries/FindJobsWithMismatchedJobMaterialsQueryHandler.cs[m
[1m+++ b/A1ServicesApp/Features/JobServiceMaterialLinks/Queries/FindJobsWithMismatchedJobMaterialsQueryHandler.cs[m
[36m@@ -27,7 +27,7 @@[m [mnamespace A1ServicesApp.Features.JobMaterials.Queries[m
             _ctx = ctx;[m
         }[m
 [m
[31m-        public Task<List<FlaggedJobServiceMaterialsDto>> Handle(FindJobsWithMismatchedJobMaterialsQuery request, CancellationToken cancellationToken)[m
[32m+[m[32m        public async Task<List<FlaggedJobServiceMaterialsDto>> Handle(FindJobsWithMismatchedJobMaterialsQuery request, CancellationToken cancellationToken)[m
         {[m
             var jobMissingMaterials = new List<ServiceTitanJobModel>();[m
             var result = new List<FlaggedJobServiceMaterialsDto>();[m
[36m@@ -137,7 +137,7 @@[m [mnamespace A1ServicesApp.Features.JobMaterials.Queries[m
                 [m
             }[m
 [m
[31m-            return Task.FromResult(result.OrderBy(r => r.TechnicianId).ThenBy(r => r.JobCompletedDate).ToList());[m
[32m+[m[32m            return await Task.FromResult(result.OrderBy(r => r.TechnicianId).ThenBy(r => r.JobCompletedDate).ToList());[m
         }[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/Jobs/JobsController.cs b/A1ServicesApp/Features/Jobs/JobsController.cs[m
[1mindex 2753e12..4d53afc 100644[m
[1m--- a/A1ServicesApp/Features/Jobs/JobsController.cs[m
[1m+++ b/A1ServicesApp/Features/Jobs/JobsController.cs[m
[36m@@ -1,9 +1,11 @@[m
[31m-﻿using A1ServicesApp.Features.Jobs.Models;[m
[32m+[m[32m﻿using A1ServicesApp.Data.Constants.ServiceTitanApiFilters;[m
[32m+[m[32musing A1ServicesApp.Features.Jobs.Models;[m
 using A1ServicesApp.Features.Jobs.Queries;[m
 using MediatR;[m
 using Microsoft.AspNetCore.Mvc;[m
 using System;[m
 using System.Collections.Generic;[m
[32m+[m[32musing System.Diagnostics;[m
 using System.Linq;[m
 using System.Text;[m
 using System.Threading.Tasks;[m
[36m@@ -29,5 +31,30 @@[m [mnamespace A1ServicesApp.Features.Jobs[m
 [m
             return Ok(result.ApiResults);[m
         }[m
[32m+[m
[32m+[m[32m        [HttpGet("groups")][m
[32m+[m[32m        public IActionResult GetJobsFromCRMGrouped([FromBody] GetJobsQueryStringModel queryString)[m
[32m+[m[32m        {[m
[32m+[m[32m            Stopwatch stopWatch = new Stopwatch();[m
[32m+[m[32m            stopWatch.Start();[m
[32m+[m[32m            var todaysDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);[m
[32m+[m
[32m+[m[32m            var queryStringModel = new GetJobsQueryStringModel()[m
[32m+[m[32m            {[m
[32m+[m[32m                ApiKey = "0a947558-f14f-4823-b948-e52533c45684",[m
[32m+[m[32m                CompletedBefore = new FilterCompletedBefore() { FilterValue = todaysDate.AddDays(0) },[m
[32m+[m[32m                CompletedAfter = new FilterCompletedAfter() { FilterValue = todaysDate.AddDays(-5) }[m
[32m+[m[32m            };[m
[32m+[m
[32m+[m[32m            var requestObject = new GetJobsFromServiceTitanQuery(queryStringModel);[m
[32m+[m[32m            var result = _mediator.Send(requestObject).Result;[m
[32m+[m[32m            stopWatch.Stop();[m
[32m+[m[32m            var groupedByCreator = result.ApiResults.GroupBy(j => j.CreatedBy.Name).OrderBy(c=>c.Key).ToList();[m
[32m+[m
[32m+[m[32m            var groupedByHour = result.ApiResults.GroupBy(j => (DateTime.Parse(j.CreatedOn)).Hour).OrderBy(g=>g.Key).ToList();[m
[32m+[m
[32m+[m[32m            return Ok(result.ApiResults);[m
[32m+[m
[32m+[m[32m        }[m
     }[m
 }[m
\ No newline at end of file[m
[1mdiff --git a/A1ServicesApp/Features/Jobs/Queries/GetJobsFromServiceTitanQueryHandler.cs b/A1ServicesApp/Features/Jobs/Queries/GetJobsFromServiceTitanQueryHandler.cs[m
[1mindex 6705919..9f042e2 100644[m
[1m--- a/A1ServicesApp/Features/Jobs/Queries/GetJobsFromServiceTitanQueryHandler.cs[m
[1m+++ b/A1ServicesApp/Features/Jobs/Queries/GetJobsFromServiceTitanQueryHandler.cs[m
[36m@@ -10,12 +10,13 @@[m [musing System.Text;[m
 using System.Threading;[m
 using System.Threading.Tasks;[m
 using A1ServicesApp.Data.ExtensionMethods;[m
[32m+[m[32musing System.IO;[m
 [m
 namespace A1ServicesApp.Features.Jobs.Queries[m
 {[m
     public class GetJobsFromServiceTitanQueryHandler : IRequestHandler<GetJobsFromServiceTitanQuery, ServiceTitanJobsListDto>[m
     {[m
[31m-        public Task<ServiceTitanJobsListDto> Handle(GetJobsFromServiceTitanQuery request, CancellationToken cancellationToken)[m
[32m+[m[32m        public async Task<ServiceTitanJobsListDto> Handle(GetJobsFromServiceTitanQuery request, CancellationToken cancellationToken)[m
         {[m
             var result = new ServiceTitanJobsListDto();[m
 [m
[36m@@ -38,7 +39,29 @@[m [mnamespace A1ServicesApp.Features.Jobs.Queries[m
 [m
             while (hasMore)[m
             {[m
[31m-                [m
[32m+[m[32m                //var pageFilter = "&filter.page=" + page + "&filter.pageSize=250";[m
[32m+[m[32m                //var requestUrl = baseRequestUrl + apiFilters + pageFilter;[m
[32m+[m
[32m+[m[32m                //var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl),HttpCompletionOption.ResponseHeadersRead);[m
[32m+[m
[32m+[m[32m                //response.EnsureSuccessStatusCode();[m
[32m+[m
[32m+[m[32m                //var stream = await response.Content.ReadAsStreamAsync();[m
[32m+[m
[32m+[m[32m                //StreamReader streamReader = new StreamReader(stream);[m
[32m+[m[32m                //JsonReader reader = new JsonTextReader(streamReader);[m
[32m+[m[32m                //JsonSerializer serializer = new JsonSerializer();[m
[32m+[m[32m                //var apiResults = serializer.Deserialize<ServiceTitanEntityCollectionResult<ServiceTitanJobModel>>(reader);[m
[32m+[m
[32m+[m[32m                //jobs.AddRange(apiResults.Data);[m
[32m+[m
[32m+[m[32m                //hasMore = apiResults.HasMore;[m
[32m+[m[32m                //page++;[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m
                 var pageFilter = "&filter.page=" + page + "&filter.pageSize=250";[m
                 var requestUrl = baseRequestUrl + apiFilters + pageFilter;[m
 [m
[36m@@ -47,14 +70,14 @@[m [mnamespace A1ServicesApp.Features.Jobs.Queries[m
 [m
                 jobs.AddRange(apiResults.Data);[m
 [m
[31m-                [m
[32m+[m
 [m
                 hasMore = apiResults.HasMore;[m
                 page++;[m
             }[m
             result.ApiResults = jobs;[m
 [m
[31m-            return Task.FromResult<ServiceTitanJobsListDto>(result);[m
[32m+[m[32m            return await Task.FromResult<ServiceTitanJobsListDto>(result);[m
         }     [m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/STWebhooks/STWebhooksController.cs b/A1ServicesApp/Features/STWebhooks/STWebhooksController.cs[m
[1mindex 637d38b..5e1fda8 100644[m
[1m--- a/A1ServicesApp/Features/STWebhooks/STWebhooksController.cs[m
[1m+++ b/A1ServicesApp/Features/STWebhooks/STWebhooksController.cs[m
[36m@@ -1,4 +1,5 @@[m
 ﻿using A1ServicesApp.Data.Entities.ServiceTitan;[m
[32m+[m[32musing A1ServicesApp.Features.Invoices.Commands;[m
 using A1ServicesApp.Features.JobMaterials.Queries;[m
 using A1ServicesApp.Features.Services.Airtable.Commands;[m
 using AutoMapper;[m
[36m@@ -25,19 +26,25 @@[m [mnamespace A1ServicesApp.Features.STWebhooks[m
         }[m
 [m
         [HttpPost("jobcompleted")][m
[31m-        public IActionResult ReceiveCompletedServiceTitanJob([FromBody]ServiceTitanPostJobCompleted_ResultModel model)[m
[32m+[m[32m        public async Task<IActionResult> ReceiveCompletedServiceTitanJob([FromBody]ServiceTitanPostJobCompleted_ResultModel model)[m
         {[m
             var job = _mapper.Map<ServiceTitanJobModel>(model);[m
 [m
             var jobList = new List<ServiceTitanJobModel>();[m
             jobList.Add(job);[m
[31m-            var resultList = _mediator.Send(new FindJobsWithMismatchedJobMaterialsQuery() { Jobs = jobList }).Result;[m
[32m+[m[32m            var resultListFindQuery = await _mediator.Send(new FindJobsWithMismatchedJobMaterialsQuery() { Jobs = jobList });[m
[32m+[m[32m            var resultInvoiceValidator = await _mediator.Send(new ValidateJobInvoiceCommand() { Job = job });[m
 [m
[31m-            foreach (var result in resultList)[m
[32m+[m[32m            foreach (var result in resultListFindQuery)[m
             {[m
[31m-                _mediator.Send(new AddInvoiceExceptionRecordToAirtableCommand() { flaggedJob = result });[m
[32m+[m[32m                await _mediator.Send(new AddInvoiceExceptionRecordToAirtableCommand() { FlaggedJob = result });[m
             }[m
[31m-            [m
[32m+[m
[32m+[m[32m            foreach (var error in resultInvoiceValidator)[m
[32m+[m[32m            {[m
[32m+[m[32m                await _mediator.Send(new AddInvoiceExceptionRecordToAirtableCommand() { InvoiceError = error });[m
[32m+[m[32m            }[m
[32m+[m
 [m
 [m
             return Ok();[m
[1mdiff --git a/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommand.cs b/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommand.cs[m
[1mindex b36b160..acda79c 100644[m
[1m--- a/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommand.cs[m
[1m+++ b/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommand.cs[m
[36m@@ -1,4 +1,5 @@[m
[31m-﻿using A1ServicesApp.Features.JobServiceMaterialLinks.Models;[m
[32m+[m[32m﻿using A1ServicesApp.Features.InvoiceValidation;[m
[32m+[m[32musing A1ServicesApp.Features.JobServiceMaterialLinks.Models;[m
 using MediatR;[m
 using System;[m
 using System.Collections.Generic;[m
[36m@@ -10,7 +11,7 @@[m [mnamespace A1ServicesApp.Features.Services.Airtable.Commands[m
 {[m
     public class AddInvoiceExceptionRecordToAirtableCommand : IRequest<Object>[m
     {[m
[31m-        public FlaggedJobServiceMaterialsDto flaggedJob { get; set; }[m
[31m-[m
[32m+[m[32m        public FlaggedJobServiceMaterialsDto FlaggedJob { get; set; }[m
[32m+[m[32m        public InvoiceError InvoiceError { get; set; }[m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommandHandler.cs b/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommandHandler.cs[m
[1mindex 5609b12..7e52bdc 100644[m
[1m--- a/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommandHandler.cs[m
[1m+++ b/A1ServicesApp/Features/Services/Airtable/Commands/AddInvoiceExceptionRecordToAirtableCommandHandler.cs[m
[36m@@ -19,11 +19,24 @@[m [mnamespace A1ServicesApp.Features.Services.Airtable.Commands[m
             var airTableBase = new AirtableBase(airtableApiKey, invoiceExceptionBaseKey);[m
 [m
             var airtableFields = new Fields();[m
[31m-            airtableFields.FieldsCollection.Add("job_id", request.flaggedJob.FlaggedJobId.ToString());[m
[31m-            airtableFields.FieldsCollection.Add("flagged_material_code", request.flaggedJob.FlaggedMaterialCode);[m
[31m-            airtableFields.FieldsCollection.Add("technician_name", request.flaggedJob.TechnicianName);[m
[31m-            airtableFields.FieldsCollection.Add("job_completed_date", DateTime.Parse(request.flaggedJob.JobCompletedDate));[m
[31m-            airtableFields.FieldsCollection.Add("job_url", "https://go.servicetitan.com/#/Job/Index/" + request.flaggedJob.FlaggedJobId.ToString());[m
[32m+[m[32m            if (request.FlaggedJob != null)[m
[32m+[m[32m            {[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("job_id", request.FlaggedJob.FlaggedJobId.ToString());[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("flagged_material_code", request.FlaggedJob.FlaggedMaterialCode);[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("technician_name", request.FlaggedJob.TechnicianName);[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("job_completed_date", DateTime.Parse(request.FlaggedJob.JobCompletedDate));[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("job_url", "https://go.servicetitan.com/#/Job/Index/" + request.FlaggedJob.FlaggedJobId.ToString());[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("service_code", request.FlaggedJob.ServiceCode);[m
[32m+[m[32m            }[m
[32m+[m[32m            if (request.InvoiceError != null)[m
[32m+[m[32m            {[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("job_id", request.InvoiceError.FlaggedJobId.ToString());[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("flagged_material_code", request.InvoiceError.FlaggedMaterialCode);[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("technician_name", request.InvoiceError.TechnicianName);[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("job_completed_date", DateTime.Parse(request.InvoiceError.JobCompletedDate));[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("job_url", "https://go.servicetitan.com/#/Job/Index/" + request.InvoiceError.FlaggedJobId.ToString());[m
[32m+[m[32m                airtableFields.FieldsCollection.Add("service_code", request.InvoiceError.ServiceCode);[m
[32m+[m[32m            }[m
 [m
             var result = airTableBase.CreateRecord("exception_list", airtableFields, true).Result;[m
 [m
[1mdiff --git a/A1ServicesApp/Program.cs b/A1ServicesApp/Program.cs[m
[1mindex 0c2681b..08998b2 100644[m
[1m--- a/A1ServicesApp/Program.cs[m
[1m+++ b/A1ServicesApp/Program.cs[m
[36m@@ -5,10 +5,7 @@[m [musing System.Linq;[m
 using System.Threading.Tasks;[m
 using Microsoft.AspNetCore;[m
 using Microsoft.AspNetCore.Hosting;[m
[31m-using Microsoft.Azure.KeyVault;[m
[31m-using Microsoft.Azure.Services.AppAuthentication;[m
 using Microsoft.Extensions.Configuration;[m
[31m-using Microsoft.Extensions.Configuration.AzureKeyVault;[m
 using Microsoft.Extensions.Logging;[m
 [m
 namespace A1ServicesApp[m
[36m@@ -24,13 +21,8 @@[m [mnamespace A1ServicesApp[m
             WebHost.CreateDefaultBuilder(args)[m
                 .ConfigureAppConfiguration((hostingContext, config) =>[m
                 {[m
[31m-                    var keyVaultEndpoint = "https://a1keyvault.vault.azure.net";[m
[31m-                    var azureServiceTokenProvider = new AzureServiceTokenProvider();[m
[31m-                    var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));[m
[31m-                    config.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());[m
[32m+[m[32m                    config.AddEnvironmentVariables();[m
                 })[m
                 .UseStartup<Startup>();[m
[31m-[m
[31m-        [m
     }[m
 }[m
[1mdiff --git a/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml b/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml[m
[1mindex 91578e6..3629d4a 100644[m
[1m--- a/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml[m	
[1m+++ b/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml[m	
[36m@@ -18,15 +18,12 @@[m [mby editing this MSBuild file. In order to learn more about this please visit htt[m
     <MSDeployServiceURL>a1servicesapp.scm.azurewebsites.net:443</MSDeployServiceURL>[m
     <DeployIisAppPath>A1ServicesApp</DeployIisAppPath>[m
     <RemoteSitePhysicalPath />[m
[31m-    <SkipExtraFilesOnServer>False</SkipExtraFilesOnServer>[m
[32m+[m[32m    <SkipExtraFilesOnServer>True</SkipExtraFilesOnServer>[m
     <MSDeployPublishMethod>WMSVC</MSDeployPublishMethod>[m
     <EnableMSDeployBackup>True</EnableMSDeployBackup>[m
     <UserName>$A1ServicesApp</UserName>[m
     <_SavePWD>True</_SavePWD>[m
     <_DestinationType>AzureWebSite</_DestinationType>[m
     <InstallAspNetCoreSiteExtension>False</InstallAspNetCoreSiteExtension>[m
[31m-    <TargetFramework>netcoreapp2.2</TargetFramework>[m
[31m-    <SelfContained>false</SelfContained>[m
[31m-    <_IsPortable>true</_IsPortable>[m
   </PropertyGroup>[m
 </Project>[m
\ No newline at end of file[m
[1mdiff --git a/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml.user b/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml.user[m
[1mindex decbb0d..a4fc647 100644[m
[1m--- a/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml.user[m	
[1m+++ b/A1ServicesApp/Properties/PublishProfiles/A1ServicesApp - Web Deploy.pubxml.user[m	
[36m@@ -8,9 +8,4 @@[m [mby editing this MSBuild file. In order to learn more about this please visit htt[m
     <TimeStampOfAssociatedLegacyPublishXmlFile />[m
     <EncryptedPassword>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+cCLP9xfWkeUWq61ZILEnAAAAAACAAAAAAAQZgAAAAEAACAAAABWNsPNLtGnDt43LRv6rhRdW/YGRjfoA6evXvvk6sH+XQAAAAAOgAAAAAIAACAAAABefNCtEVrERToXyo8iE0idw26090F0hQUD7LwB9+IHU4AAAAADtOIDlQVAPzh0DOS7B/FcdGjY4dxLhGzDWbxbgFE0cqqyoGpV2TkqUMbqecbP6+LBxXhIUrEBPAvlug5t1oteLU+5uf19LOwxpLEIZdA56qIDUDI4VbkLNaJE8KrUa/bhLtMdvX8yTQ+i/oknAnN04p1I9To7zM8lzj2J5yZjvEAAAACHpEkSOjFfV0hqVoLBhE/X5naSB497VEmwFvH9werNgr1PUH+vuIw12KCw1Jq3U+CvBZokW6aA3Cn6lRGlsZUW</EncryptedPassword>[m
   </PropertyGroup>[m
[31m-  <ItemGroup>[m
[31m-    <DestinationConnectionStrings Include="DefaultConnection">[m
[31m-      <Value>Server=tcp:a1servicesappdbserver.database.windows.net,1433%3bInitial Catalog=a1servicesappdblive%3bPersist Security Info=False%3bUser ID=moldehoff%3bPassword=Mo020994!%3bMultipleActiveResultSets=True%3bEncrypt=True%3bTrustServerCertificate=False%3bConnection Timeout=30%3b</Value>[m
[31m-    </DestinationConnectionStrings>[m
[31m-  </ItemGroup>[m
 </Project>[m
\ No newline at end of file[m
[1mdiff --git a/A1ServicesApp/Startup.cs b/A1ServicesApp/Startup.cs[m
[1mindex 036c278..492c60e 100644[m
[1m--- a/A1ServicesApp/Startup.cs[m
[1m+++ b/A1ServicesApp/Startup.cs[m
[36m@@ -1,12 +1,9 @@[m
 ﻿using System;[m
 using System.Collections.Generic;[m
[31m-using System.ComponentModel;[m
[31m-using System.Data;[m
[31m-using System.Data.Common;[m
[31m-using System.Data.SqlClient;[m
 using System.Linq;[m
 using System.Threading.Tasks;[m
 using A1ServicesApp.Data;[m
[32m+[m[32musing A1ServicesApp.Features.InvoiceValidation;[m
 using AutoMapper;[m
 using MediatR;[m
 using Microsoft.AspNetCore.Builder;[m
[36m@@ -19,11 +16,11 @@[m [musing Microsoft.Azure.Management.ResourceManager.Fluent;[m
 using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;[m
 using Microsoft.Azure.Services.AppAuthentication;[m
 using Microsoft.EntityFrameworkCore;[m
[31m-using Microsoft.EntityFrameworkCore.Infrastructure;[m
 using Microsoft.Extensions.Configuration;[m
 using Microsoft.Extensions.DependencyInjection;[m
 using Microsoft.Extensions.Logging;[m
 using Microsoft.Extensions.Options;[m
[32m+[m[32musing Newtonsoft.Json;[m
 [m
 namespace A1ServicesApp[m
 {[m
[36m@@ -39,17 +36,19 @@[m [mnamespace A1ServicesApp[m
         // This method gets called by the runtime. Use this method to add services to the container.[m
         public void ConfigureServices(IServiceCollection services)[m
         {[m
[31m-            var connectionString =_config["DbConnectionString"];[m
[31m-[m
[31m-            services.AddDbContext<A1ServicesAppDbContext>(o => o.UseSqlServer(connectionString));[m
             [m
[32m+[m[32m            services.AddDbContext<A1ServicesAppDbContext>(o => o.UseSqlServer(_config.GetConnectionString("DbConnectionString")));[m
[32m+[m
             services.AddMediatR();[m
 [m
             services.AddMvc()[m
                 .AddFeatureFolders()[m
[32m+[m[32m                .AddJsonOptions(o=>o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)[m
                 .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);[m
 [m
             services.AddAutoMapper();[m
[32m+[m
[32m+[m[32m            services.AddTransient<TaskMaterialValidatorFactory>();[m
         }[m
 [m
         [m
[36m@@ -64,7 +63,6 @@[m [mnamespace A1ServicesApp[m
             else[m
             {[m
                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.[m
[31m-                app.UseExceptionHandler("/Error");[m
                 app.UseHsts();[m
             }[m
 [m
[1mdiff --git a/A1ServicesApp/appsettings.json b/A1ServicesApp/appsettings.json[m
[1mindex 20791a5..598d296 100644[m
[1m--- a/A1ServicesApp/appsettings.json[m
[1m+++ b/A1ServicesApp/appsettings.json[m
[36m@@ -1,12 +1,5 @@[m
 {[m
[31m-  "ConnectionStrings": {[m
[31m-    "DefaultConnection": "data source=a1servicesappdbserver.database.windows.net;initial catalog=a1servicesappdblive;persist security info=True;MultipleActiveResultSets=True;"[m
[31m-  },[m
[31m-  "KeyVault": {[m
[31m-    "ClientId": "ce500977-1aa4-4771-bf08-8b8156ad6020",[m
[31m-    "ClientSecret": "hPF/rkarb+Sf508MQHA9UwnrUDEN9rP6C7BQNLzoq2E=",[m
[31m-    "ConnectionStringSecretUri": "https://a1keyvault.vault.azure.net/secrets/DbConnectionString/f5c383b62e514fc69286cb2039174446"[m
[31m-  },[m
[32m+[m
   "Logging": {[m
     "IncludeScopes": false,[m
     "Debug": {[m
[1mdiff --git a/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.deps.json b/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.deps.json[m
[1mindex 4c6c557..90500c9 100644[m
[1m--- a/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.deps.json[m
[1m+++ b/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.deps.json[m
[36m@@ -37,8 +37,7 @@[m
           "Microsoft.Azure.Services.AppAuthentication": "1.0.3",[m
           "Microsoft.Extensions.Configuration.AzureKeyVault": "2.2.0",[m
           "Microsoft.NETCore.App": "2.2.0",[m
[31m-          "OdeToCode.AddFeatureFolders": "2.0.3",[m
[31m-          "System.Data.SqlClient": "4.6.0"[m
[32m+[m[32m          "OdeToCode.AddFeatureFolders": "2.0.3"[m
         },[m
         "runtime": {[m
           "A1ServicesApp.dll": {}[m
[1mdiff --git a/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.dll b/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.dll[m
[1mindex 8ecec3e..ea82b1f 100644[m
Binary files a/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.dll and b/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.dll differ
[1mdiff --git a/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.pdb b/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.pdb[m
[1mindex f75271f..da76efd 100644[m
Binary files a/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.pdb and b/A1ServicesApp/bin/Debug/netcoreapp2.2/A1ServicesApp.pdb differ
[1mdiff --git a/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.deps.json b/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.deps.json[m
[1mindex 2b0d08e..ebcf35d 100644[m
[1m--- a/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.deps.json[m
[1m+++ b/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.deps.json[m
[36m@@ -37,8 +37,7 @@[m
           "Microsoft.Azure.Services.AppAuthentication": "1.0.3",[m
           "Microsoft.Extensions.Configuration.AzureKeyVault": "2.2.0",[m
           "Microsoft.NETCore.App": "2.2.0",[m
[31m-          "OdeToCode.AddFeatureFolders": "2.0.3",[m
[31m-          "System.Data.SqlClient": "4.6.0"[m
[32m+[m[32m          "OdeToCode.AddFeatureFolders": "2.0.3"[m
         },[m
         "runtime": {[m
           "A1ServicesApp.dll": {}[m
[36m@@ -3779,7 +3778,7 @@[m
     "Microsoft.NETCore.DotNetAppHost/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-qIrVLupwT2NYTrf7KM7Nh+mJr36V5MITVRjyGOByVVCwGmQgQmI/6bjZYQv+QdExi4Cm87eCKJX9FdT6nc00Xg==",[m
[32m+[m[32m      "sha512": "sha512-OK/H8p9Ig6mLMITjXJ4VOewrJg/TU+dAPHE4BdMWMv+8COzBehf7XF1+DofKkmqdHpO2cJoS5Sc9PEZ6PKCbsg==",[m
       "path": "microsoft.netcore.dotnetapphost/2.2.0",[m
       "hashPath": "microsoft.netcore.dotnetapphost.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4052,7 +4051,7 @@[m
     "Microsoft.AspNetCore.Cryptography.KeyDerivation/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-QJQZNdLDKReVNAalMwOU7B8chV0VlxJyjt8fSnZtSUDW54zDJEpQHQfF/PqiNM49HSE5sQilqTWJirV8eqxhpg==",[m
[32m+[m[32m      "sha512": "sha512-gKQAO+xmGb8cHXrDURoT+JIzfBQnZyXcYkuNuiUoNk5LesSDc7CTCH7fya/PHh9g3JxtceDA1vZbbn9BktGMug==",[m
       "path": "microsoft.aspnetcore.cryptography.keyderivation/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.cryptography.keyderivation.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4073,14 +4072,14 @@[m
     "Microsoft.AspNetCore.DataProtection.Extensions/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-GfxmwmIeZGyiEmmXKb6ObuiCueiahLhCyP+GL2RCBgHg71OJk0UnsuQVAwV66nz/ym/ODFMbYfo6Pvz123ShTA==",[m
[32m+[m[32m      "sha512": "sha512-SdOyLQQlYLO7P08LFLzjJVJW7PCv62CnyXJHT3Q+4ZjLc1eVWgz+1C0/E6rBKhF/z5zkFClgPEEYOK1lGhqtBw==",[m
       "path": "microsoft.aspnetcore.dataprotection.extensions/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.dataprotection.extensions.2.2.0.nupkg.sha512"[m
     },[m
     "Microsoft.AspNetCore.Diagnostics/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-IkLnaJw/7j6ejSfkhPRbxRKfcZnSWDJ6hTXf+3afCYGUJ1hqSf3qTfS56JV7mgZZud1hQKm1FfdTpzwxZ6jnzg==",[m
[32m+[m[32m      "sha512": "sha512-QJHBQ6brad6JSaeJ+th6cJDfxDAWIZywFFmpeUsG42gUFWM2CIqIRlHv7oiI06PAdL0uoG5GnU+7gDDe8tjsYQ==",[m
       "path": "microsoft.aspnetcore.diagnostics/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.diagnostics.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4094,7 +4093,7 @@[m
     "Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-rXQcHRHxtJIQILyva81Q5rr+S40WV6G3IIuGcS6zrWtdDAfB/oaDKLZLQ8l9uSd3o4WEikRtsgZkR5Mmh141ZQ==",[m
[32m+[m[32m      "sha512": "sha512-hiHQ+L8R8mXnlTPB7zsV1iYc/1J6bqd3NwS3y/9mM/OLPxldoRA/WGcBs8j1HRH1OTtobLi1+vDFh6a4CDsUZw==",[m
       "path": "microsoft.aspnetcore.diagnostics.entityframeworkcore/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.diagnostics.entityframeworkcore.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4136,7 +4135,7 @@[m
     "Microsoft.AspNetCore.Html.Abstractions/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-Z08ZN/kjJ15AQyNY349dpTPJdpdVJ/RYLLJjY9sf6VoHBf3vRBSCBx6orXMspMeRJrhHultPTP0IKVK2g4KZxg==",[m
[32m+[m[32m      "sha512": "sha512-NDyH+7k7iuedeOJfoUEIxUynePOPIHj5qNGnHBOenoy51HDNsdzqA4TXsjBM5/9N9nz9hzYEriHoYHc2EcxV4Q==",[m
       "path": "microsoft.aspnetcore.html.abstractions/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.html.abstractions.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4164,14 +4163,14 @@[m
     "Microsoft.AspNetCore.Http.Connections.Common/1.1.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-QqS75Fj6lBCkZT+XWU5GmhqPrzaGVaEYec4wXFQWiHdttJQaziybCHUODkVzw1WErBPfPTYW75Mredbj89Yqiw==",[m
[32m+[m[32m      "sha512": "sha512-7TkyoUY+I01zXaF43dgaqF3Ej6NWWEXyiKjbJLovYInMEQ4Zwus2HdrayEPFTiiEH2hkCn9o5Vn162qux3NmhQ==",[m
       "path": "microsoft.aspnetcore.http.connections.common/1.1.0",[m
       "hashPath": "microsoft.aspnetcore.http.connections.common.1.1.0.nupkg.sha512"[m
     },[m
     "Microsoft.AspNetCore.Http.Extensions/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-wXfB68sp3X+6/TLUHVF5eiscn9iGptGEwjJyk4yBbbOAVJECE59/KUun6sT+JlNcNCWEWE0S7Ew+yMD6bm3rrQ==",[m
[32m+[m[32m      "sha512": "sha512-lyEExtXdag+/tGhJVJgU6s2LOEUO3Uex4bDjN2RWuOYPe0l4rTDFv8B1WJO3EnnFrcCbbhATEc+3y3ntzSZKqw==",[m
       "path": "microsoft.aspnetcore.http.extensions/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.http.extensions.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4185,7 +4184,7 @@[m
     "Microsoft.AspNetCore.HttpOverrides/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-7NCmNmYah9rPWeRTBNd2h0F4fba8zi6yYGcXw23rr/sZPKbtdg/lkgD/KRGaNefVuwnP+IH7uTi6/RuvZQn/Wg==",[m
[32m+[m[32m      "sha512": "sha512-27541I282qw8FEO8nge/bIzz1kntQZlM/TuRrAtscjjsVCmb/KsV6Bi2dlVAxIqdSKLhJ84zm6Ml8NR6NJQHzw==",[m
       "path": "microsoft.aspnetcore.httpoverrides/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.httpoverrides.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4304,7 +4303,7 @@[m
     "Microsoft.AspNetCore.Mvc.Formatters.Xml/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-B/d5F7bVNmfVbwQvOUxxrWMzasqAOHtq9T/E84qXP4inFeE4WF/2ehmX+ylDwSRu6r7oL6SKhoLb7YRhQTSUkA==",[m
[32m+[m[32m      "sha512": "sha512-DKBrtBHQngHPROljcC3vmsH+SJYsM0gVkv3s949T6EYELUvg20JcZu5j1G28icqyhiqYMZSDNxORAHNG7xsGxQ==",[m
       "path": "microsoft.aspnetcore.mvc.formatters.xml/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.mvc.formatters.xml.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4416,7 +4415,7 @@[m
     "Microsoft.AspNetCore.ResponseCompression/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-xETcZODoAhqelysOOrHzyBV9mZYkaYwvjsN6rf9yb4K61Bb9JUJORscOzFQJpD+wgeMVYwptXz9eYhJ6Me8fZw==",[m
[32m+[m[32m      "sha512": "sha512-UrTC8M2eywUltCFRpF0Q4nrvgr/3oRnG+9xarL3sVs4PBn1OfpSyzC8yigR3ditkVs52NJ1RN2dmavhS6URm/A==",[m
       "path": "microsoft.aspnetcore.responsecompression/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.responsecompression.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4444,7 +4443,7 @@[m
     "Microsoft.AspNetCore.Server.HttpSys/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-JjsGTR6OFq7ZX+n56+3r8Q0hgbXGBPBFvkxYc+6+xf/bsoYhWtK+bf8BqM9tQKHgBcyVYcL1a843CEpYGUoN1w==",[m
[32m+[m[32m      "sha512": "sha512-w85cPN4/O/80UZKks8Xbxjx2CcdQ98gEUHslYVUPsdY7HA9IriQazEaJiyPwXMad6HueCVqXqWi7L27h2KCuxQ==",[m
       "path": "microsoft.aspnetcore.server.httpsys/2.2.0",[m
       "hashPath": "microsoft.aspnetcore.server.httpsys.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4724,21 +4723,21 @@[m
     "Microsoft.Extensions.Configuration.FileExtensions/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-1cO9Ca+lLh7mRTbJYEXnGPqoVMt/71BM7zmcZx6VOFLEBAfpOej/isDtgqRYhDcMkLaS9vn9pXerp41fTO9y1w==",[m
[32m+[m[32m      "sha512": "sha512-BnkmTopJ7m+p0/EBshdJmoWroUvMlu+oA+bDvzEWh3WA9rOYdnTZueQ7Ap1oSfUnHnPBnuWae/ED8hHlM/sQxA==",[m
       "path": "microsoft.extensions.configuration.fileextensions/2.2.0",[m
       "hashPath": "microsoft.extensions.configuration.fileextensions.2.2.0.nupkg.sha512"[m
     },[m
     "Microsoft.Extensions.Configuration.Ini/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-YERPpTxyyuCW+9HWvJ5W6J2AHHNbNA4bsuzeGAr/5BKn7dqeZTbIKk1gRAKG0MmE10Z0RA6DU+sx2B4oE0Z0YQ==",[m
[32m+[m[32m      "sha512": "sha512-yhk3VIuf1HyViMujaJ+Ieboz+lVkF8jP5Tx+9dPbnGFiQ0SwLVoukbGfZ8gkyDTpB5/VBQZ+omg4iTC3AuEfyw==",[m
       "path": "microsoft.extensions.configuration.ini/2.2.0",[m
       "hashPath": "microsoft.extensions.configuration.ini.2.2.0.nupkg.sha512"[m
     },[m
     "Microsoft.Extensions.Configuration.Json/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-vqJEFHHDVTDhjTTdX8QZWF75Hw9bFLbmRcjRbXtmQLrFBvcTzuS9w1jJGWjrgR1UQ7YpuJdhcDXzhxorqkR1Ig==",[m
[32m+[m[32m      "sha512": "sha512-CqqFzpFuW9rOWOHI9c3JrGrOOogfLRrGTWVU2AIFkxXRQ/bAg5lL3WabkVEywmTRo58AI3p6sT0ACNy9s279VA==",[m
       "path": "microsoft.extensions.configuration.json/2.2.0",[m
       "hashPath": "microsoft.extensions.configuration.json.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4752,14 +4751,14 @@[m
     "Microsoft.Extensions.Configuration.UserSecrets/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-Z8ooq2NNyy40g7f/tfTABARrkUeVxeoyh4U/mLUCVEKhP278Ws0EkLO9yeR0YKLsM89Na940D+1NM+n2A4yufA==",[m
[32m+[m[32m      "sha512": "sha512-c9QO9KPMxeGzzPJShGxBi/b7ZxMp/EePdcuq1Rk4kVIR0/tgAmp1Is1a1R/5GASVWBwXAV0xrSiGpE+bNBAF1w==",[m
       "path": "microsoft.extensions.configuration.usersecrets/2.2.0",[m
       "hashPath": "microsoft.extensions.configuration.usersecrets.2.2.0.nupkg.sha512"[m
     },[m
     "Microsoft.Extensions.Configuration.Xml/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-2VCbpnfQuyk8slmdT/0JdMaQ969WcT+RMCVZmInDGlorsBNpPCNPD38q0sBe1wM+suf/Wh3kA6kbXh7LwIrvaw==",[m
[32m+[m[32m      "sha512": "sha512-tfy0O96HobVaAzZBUjg+yN7P30nCKdp5IwgOBcaU6623b+77oBSQ70XH8tBEk6AfbO5kryzYjOHVr9mjSomI6Q==",[m
       "path": "microsoft.extensions.configuration.xml/2.2.0",[m
       "hashPath": "microsoft.extensions.configuration.xml.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4787,7 +4786,7 @@[m
     "Microsoft.Extensions.DiagnosticAdapter/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-p9v9EqIGH7q1luc10CY6NkvPRNKdjvWAMPfv9cGK75jkGxcWeJd/2toASRdk+NUch8Elk7kzwauyp/iDXkoGVg==",[m
[32m+[m[32m      "sha512": "sha512-Vy+NDLJHnena9L2l135BDHzWNAkEvi9mb11oVsZC6K5v9ClPxzNvplV7qJstpK9/Rdpulcz7E7yTamHLU8zMtg==",[m
       "path": "microsoft.extensions.diagnosticadapter/2.2.0",[m
       "hashPath": "microsoft.extensions.diagnosticadapter.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4829,7 +4828,7 @@[m
     "Microsoft.Extensions.FileProviders.Physical/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-Qt6sUa56/XbLxYshrCzwJYhHO9TkVa9Adch1qVqr7PGuLCxRs3K7nGMv3I6msUvAJqiJE33Oexz6KrT4hcUHgA==",[m
[32m+[m[32m      "sha512": "sha512-lFYs3tCesMedXt/sUHIUlByH20qxi6DjSxOTyRvqT3YUMteqsVIGgjcF8zoVWMfvlv9/418Uk3eC3bFn8Qc+rA==",[m
       "path": "microsoft.extensions.fileproviders.physical/2.2.0",[m
       "hashPath": "microsoft.extensions.fileproviders.physical.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4850,7 +4849,7 @@[m
     "Microsoft.Extensions.Hosting.Abstractions/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-tqXaCEeEeuDchJ482wwU2bHyu5UUksVrLyLsrvE9kPFYyPz7Hq17Ryq+faQP/zBCpnnqP/wqf3oSR0q60Py3HA==",[m
[32m+[m[32m      "sha512": "sha512-Uupv0fAgMVBgx6xKnlm4TRrD+aTBQBXCr1QxDFREK+oQ4wrG2lCEmIeqn0YhS17H8T+bRKXTyFBCB5LrOZelWw==",[m
       "path": "microsoft.extensions.hosting.abstractions/2.2.0",[m
       "hashPath": "microsoft.extensions.hosting.abstractions.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4885,7 +4884,7 @@[m
     "Microsoft.Extensions.Localization.Abstractions/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-RMybKFzUHKTiLGKOeDU1AX543ce5kHfn2CBwPeG1kbLo0YMtaR0nngPyFaL1lHv6TrrKWPCfO6p+45dyfPTGgQ==",[m
[32m+[m[32m      "sha512": "sha512-+hSkcuST/PvRHFfNUyVn/v0JreREgAfTVWaqNVoz9qrVw2pD1bw4Sq9B+TKl3qBT+7c2p+TAir54VtXcF9BzMg==",[m
       "path": "microsoft.extensions.localization.abstractions/2.2.0",[m
       "hashPath": "microsoft.extensions.localization.abstractions.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -4969,7 +4968,7 @@[m
     "Microsoft.Extensions.Primitives/2.2.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-Sv8EDHvN2852bE5G1yosKCa7sUw/x0Z/rCaI5LIWHseAXprG1h9oberAh3NRBO7w2zTZq79WPeQDMsPBVSf99w==",[m
[32m+[m[32m      "sha512": "sha512-vpH+o7f8obVx65PiEtBXxTwL5RosK60fNIMy/y8WGE4/r4IvAqQGukOzMhxsp//Accvd7kmukyQTVkqVYdaDyA==",[m
       "path": "microsoft.extensions.primitives/2.2.0",[m
       "hashPath": "microsoft.extensions.primitives.2.2.0.nupkg.sha512"[m
     },[m
[36m@@ -5116,7 +5115,7 @@[m
     "runtime.native.System.Net.Http/4.3.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-guqHgQOK2eUgtJae2VKjNawBn1xjC0hfOt5wASHa60XHbIdCsQlqtvMsFG+3hy7yp88V+gi9fZCjubuDkeakcQ==",[m
[32m+[m[32m      "sha512": "sha512-ZVuZJqnnegJhd2k/PtAbbIcZ3aZeITq3sj06oKfMBSfphW3HDmk/t4ObvbOk/JA/swGR0LNqMksAh/f7gpTROg==",[m
       "path": "runtime.native.system.net.http/4.3.0",[m
       "hashPath": "runtime.native.system.net.http.4.3.0.nupkg.sha512"[m
     },[m
[36m@@ -5130,7 +5129,7 @@[m
     "runtime.native.System.Security.Cryptography.OpenSsl/4.3.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-wWqB5kJ+vYC+IH7orP8EezottaOczECwYBFcecbkgG3IG6s8WghUdmM6pbUqSLhPibItxCWNg73rvG5cbL9tmw==",[m
[32m+[m[32m      "sha512": "sha512-NS1U+700m4KFRHR5o4vo9DSlTmlCKu/u7dtE5sUHVIPB+xpXxYQvgBgA6wEIeCz6Yfn0Z52/72WYsToCEPJnrw==",[m
       "path": "runtime.native.system.security.cryptography.openssl/4.3.0",[m
       "hashPath": "runtime.native.system.security.cryptography.openssl.4.3.0.nupkg.sha512"[m
     },[m
[36m@@ -5158,7 +5157,7 @@[m
     "runtime.osx.10.10-x64.runtime.native.System.Security.Cryptography.OpenSsl/4.3.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-/p8IQT2brFMDa7BHMH71LV+w5Tb3OxoLHxhn6+MGqN5xeqhM2HRHmj+7xQGJnaRn73d7ZTvp6yRCFMvolws4wA==",[m
[32m+[m[32m      "sha512": "sha512-X7IdhILzr4ROXd8mI1BUCQMSHSQwelUlBjF1JyTKCjXaOGn2fB4EKBxQbCK2VjO3WaWIdlXZL3W6TiIVnrhX4g==",[m
       "path": "runtime.osx.10.10-x64.runtime.native.system.security.cryptography.openssl/4.3.0",[m
       "hashPath": "runtime.osx.10.10-x64.runtime.native.system.security.cryptography.openssl.4.3.0.nupkg.sha512"[m
     },[m
[36m@@ -5221,7 +5220,7 @@[m
     "System.Buffers/4.5.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-xpHYjjtyTEpzMwtSQBWdVc3dPjLdQtvyUg6fBlBqcLl1r2Y7gDG/W/enAYOB98nG3oD3Q153Y2FBO8JDWd+0Xw==",[m
[32m+[m[32m      "sha512": "sha512-09yL/QiPEDZI9JLg0R0OcGe/0ycFm69QN16DCvXkqkIorCC1Y2EKwk5KvSlfMmGse+LcKkD3H+Cra7fFkxHXEg==",[m
       "path": "system.buffers/4.5.0",[m
       "hashPath": "system.buffers.4.5.0.nupkg.sha512"[m
     },[m
[36m@@ -5263,7 +5262,7 @@[m
     "System.ComponentModel.Annotations/4.5.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-IjDa643EO77A4CL9dhxfZ6zzGu+pM8Ar0NYPRMN3TvDiga4uGDzFHOj/ArpyNxxKyO5IFT2LZ0rK3kUog7g3jA==",[m
[32m+[m[32m      "sha512": "sha512-f1ApUHGWq/lJC8PZE7JqbA3tiY7ZngZQO2mbYfCG0JlQVVUqqmVMAy0fMvAwEuG639M47ELdP6PQxc5OIo6i6A==",[m
       "path": "system.componentmodel.annotations/4.5.0",[m
       "hashPath": "system.componentmodel.annotations.4.5.0.nupkg.sha512"[m
     },[m
[36m@@ -5277,14 +5276,14 @@[m
     "System.Data.SqlClient/4.6.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-cppLAiY36su7Hr9dOaeDXRkndLKtnh7HgQgOfAgV0oN764BQXShll7yBZ8OwPtdYUSuwTT0re7eDQPGhwnojVQ==",[m
[32m+[m[32m      "sha512": "sha512-DLhg881ETdy/OmlbBCjfXGVU2Xlm9x5yHwhcl33SAfCIG05hAbgMcvHUZruIG1sBJolGzDhes7R7hAKPS1SOqw==",[m
       "path": "system.data.sqlclient/4.6.0",[m
       "hashPath": "system.data.sqlclient.4.6.0.nupkg.sha512"[m
     },[m
     "System.Diagnostics.Contracts/4.3.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-eelRRbnm+OloiQvp9CXS0ixjNQldjjkHO4iIkR5XH2VIP8sUB/SIpa1TdUW6/+HDcQ+MlhP3pNa1u5SbzYuWGA==",[m
[32m+[m[32m      "sha512": "sha512-hQjC+dSe1rBacyz3Qh4hooO4bWhG3/pzIL4bsMHPsLCWAQ5xfNYIuB7sU7pVZSV2v/p7DcrX6U7qAjZKJSaigg==",[m
       "path": "system.diagnostics.contracts/4.3.0",[m
       "hashPath": "system.diagnostics.contracts.4.3.0.nupkg.sha512"[m
     },[m
[36m@@ -5459,7 +5458,7 @@[m
     "System.Numerics.Vectors/4.5.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-MNcaYxUJvUcoXOa+jgKl/GDw/Mh+wMrxDjW4dre7qrp35LUGTjUBNtZsNjxsWX592ocdyqt1X5hMJB+5OStoYw==",[m
[32m+[m[32m      "sha512": "sha512-nATsBTD2CKr4AYN6eRszhX4sptImWmBJwB/U6XKCWWfnCcrTBw8XSCm3QA9gjppkHTr8OkXUY21MR91D3QZXsw==",[m
       "path": "system.numerics.vectors/4.5.0",[m
       "hashPath": "system.numerics.vectors.4.5.0.nupkg.sha512"[m
     },[m
[36m@@ -5627,7 +5626,7 @@[m
     "System.Security.Cryptography.Cng/4.5.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-DsHSZoBeVe2bAknPwdrgnCQlgd80XRcS8V3ev952BF8ZE4jUi2i7+tIaFth6md9nure1SJL2hfQt4IgjpNybxQ==",[m
[32m+[m[32m      "sha512": "sha512-O4tqXxWCD8y1IU1VTgzbuBFwoRahrADhDUxHjwezhHCsqyFNyQ5EytjWBxu0EsZuH14b4UO2pFkG063K2h/9Ug==",[m
       "path": "system.security.cryptography.cng/4.5.0",[m
       "hashPath": "system.security.cryptography.cng.4.5.0.nupkg.sha512"[m
     },[m
[36m@@ -5648,7 +5647,7 @@[m
     "System.Security.Cryptography.OpenSsl/4.3.0": {[m
       "type": "package",[m
       "serviceable": true,[m
[31m-      "sha512": "sha512-vOYy7Jv9KsG3ld2hLt0GoERd82SZi4BelrbXLwI9yFBYX7kpbvUCWYo4eyevk47cuJXZ9ZLVAryANcc7iY71aA==",[m
[32m+[m[32m      "sha512": "sha512-h4CEgOgv5PKVF/HwaHzJRiVboL2THYCou97zpmhjghx5frc7fIvlkY1jL+lnIQyChrJDMNEXS6r7byGif8Cy4w==",[m
       "path": "system.security.cryptography.openssl/4.3.0",[m
       "hashPath": "system.security.cryptography.openssl.4.3.0.nupkg.sha512"[m
     },[m
[1mdiff --git a/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.dll b/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.dll[m
[1mindex ef7ee16..b2c9d7d 100644[m
Binary files a/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.dll and b/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.dll differ
[1mdiff --git a/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.pdb b/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.pdb[m
[1mindex ce8920b..d6ffb97 100644[m
Binary files a/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.pdb and b/A1ServicesApp/bin/Release/netcoreapp2.2/A1ServicesApp.pdb differ
