using Microsoft.EntityFrameworkCore;
using ManagmentAppTestOne.Shared.Entities;


namespace ManagmentAppTestOne.Server.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
