using A1ServicesApp.Data.Entities.ServiceMaterials;
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

        public DbSet<JobServiceMaterialLink> JobServiceMaterialLinks { get; set; }
        public DbSet<JobService> JobServices { get; set; }
        public DbSet<JobMaterial> JobMaterials { get; set; }
        public DbSet<MaterialListItem> MaterialListItems { get; set; }

    }
}
