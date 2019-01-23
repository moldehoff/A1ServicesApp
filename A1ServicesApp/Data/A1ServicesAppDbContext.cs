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



    }
}
