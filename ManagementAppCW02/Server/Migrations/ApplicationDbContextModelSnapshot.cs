﻿// <auto-generated />
using System;
using ManagementAppCW02.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementAppCW02.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ManagementAppCW02.Shared.Entities.CompanyEntity", b =>
                {
                    b.Property<Guid>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("establishedDate")
                        .HasColumnType("Date");

                    b.Property<int>("numOfEmployees")
                        .HasColumnType("int");

                    b.HasKey("companyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ManagementAppCW02.Shared.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("companyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("projectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectStartedDate")
                        .HasColumnType("Date");

                    b.Property<string>("projectStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("projectId");

                    b.HasIndex("companyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ManagementAppCW02.Shared.Entities.ProjectEntity", b =>
                {
                    b.HasOne("ManagementAppCW02.Shared.Entities.CompanyEntity", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ManagementAppCW02.Shared.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
