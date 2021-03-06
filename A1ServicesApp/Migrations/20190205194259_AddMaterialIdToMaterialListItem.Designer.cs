﻿// <auto-generated />
using System;
using A1ServicesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace A1ServicesApp.Migrations
{
    [DbContext(typeof(A1ServicesAppDbContext))]
    [Migration("20190205194259_AddMaterialIdToMaterialListItem")]
    partial class AddMaterialIdToMaterialListItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("A1ServicesApp.Data.Entities.ServiceMaterials.JobServiceMaterialLink", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Active");

                    b.Property<string>("Name");

                    b.Property<string>("ServiceCode");

                    b.Property<int?>("ServiceId");

                    b.HasKey("Id");

                    b.ToTable("JobServiceMaterialLinks");
                });

            modelBuilder.Entity("A1ServicesApp.Data.Entities.ServiceMaterials.MaterialList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("JobServiceMaterialLinkId");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("JobServiceMaterialLinkId");

                    b.ToTable("MaterialList");
                });

            modelBuilder.Entity("A1ServicesApp.Data.Entities.ServiceMaterials.MaterialListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobMaterialId");

                    b.Property<int>("MaterialId");

                    b.Property<int>("MaterialListId");

                    b.HasKey("Id");

                    b.HasIndex("JobMaterialId");

                    b.HasIndex("MaterialListId");

                    b.ToTable("MaterialListItems");
                });

            modelBuilder.Entity("A1ServicesApp.Features.JobMaterials.Models.JobMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Active");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("Code");

                    b.Property<double>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("MaterialId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("JobMaterials");
                });

            modelBuilder.Entity("A1ServicesApp.Features.JobMaterials.Models.JobService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Active");

                    b.Property<double?>("AddOnMemberPrice");

                    b.Property<double?>("AddOnPrice");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<double?>("MemberPrice");

                    b.Property<string>("Name");

                    b.Property<double?>("Price");

                    b.Property<int?>("ServiceId");

                    b.HasKey("Id");

                    b.ToTable("JobServices");
                });

            modelBuilder.Entity("A1ServicesApp.Data.Entities.ServiceMaterials.MaterialList", b =>
                {
                    b.HasOne("A1ServicesApp.Data.Entities.ServiceMaterials.JobServiceMaterialLink")
                        .WithMany("MaterialLists")
                        .HasForeignKey("JobServiceMaterialLinkId");
                });

            modelBuilder.Entity("A1ServicesApp.Data.Entities.ServiceMaterials.MaterialListItem", b =>
                {
                    b.HasOne("A1ServicesApp.Features.JobMaterials.Models.JobMaterial", "JobMaterial")
                        .WithMany("MaterialListItems")
                        .HasForeignKey("JobMaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("A1ServicesApp.Data.Entities.ServiceMaterials.MaterialList", "MaterialList")
                        .WithMany("MaterialListItems")
                        .HasForeignKey("MaterialListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
