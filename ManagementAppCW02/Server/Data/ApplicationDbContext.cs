using ManagementAppCW02.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace ManagementAppCW02.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // All the tables come here
        public DbSet<CompanyEntity> Companies { get; set; }
    }
}
