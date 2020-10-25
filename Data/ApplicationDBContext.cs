using Calendar.Models;
using Microsoft.EntityFrameworkCore;
namespace Calendar.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<CriticalDate> CriticalDates { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}