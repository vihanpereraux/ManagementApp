using Microsoft.EntityFrameworkCore;
using ManagementAppCW02.Shared.Models;

namespace ManagementAppCW02.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // All the tables come here
        public DbSet<CompanyModel> Companies { get; set; }
    }
}
