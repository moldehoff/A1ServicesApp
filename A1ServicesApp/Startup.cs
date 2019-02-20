using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A1ServicesApp.Data;
using A1ServicesApp.Features.InvoiceValidation;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace A1ServicesApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<A1ServicesAppDbContext>(o => o.UseSqlServer(_config.GetConnectionString("DbConnectionString")));

            services.AddMediatR();

            services.AddMvc()
                .AddFeatureFolders()
                .AddJsonOptions(o=>o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper();

            services.AddTransient<TaskMaterialValidatorFactory>();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, A1ServicesAppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //dbContext.EnsureSeedData();

            app.UseHttpsRedirection();
            app.UseMvc();
        }


       
    }
}
