using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POE_ST10084795.Models;

namespace POE_ST10084795.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<POE_ST10084795.Models.SemesterAndModule> SemesterAndModule { get; set; }
        public DbSet<POE_ST10084795.Models.SetAsideDay> SetAsideDay { get; set; }
    }
}