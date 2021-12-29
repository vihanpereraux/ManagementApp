using Microsoft.EntityFrameworkCore;
using ManagmentAppTestOne.Shared.Entities;
using ManagmentAppTestOne.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ManagmentAppTestOne.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CollaborationEntity> Collaborations { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }

    }
}
