// <auto-generated />
using System;
using ManagmentAppTestOne.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagmentAppTestOne.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211220022421_RequiredLabelsRemoved")]
    partial class RequiredLabelsRemoved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManagmentAppTestOne.Shared.Entities.CompanyEntity", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ManagmentAppTestOne.Shared.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ManagmentAppTestOne.Shared.Entities.ProjectEntity", b =>
                {
                    b.HasOne("ManagmentAppTestOne.Shared.Entities.CompanyEntity", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ManagmentAppTestOne.Shared.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
