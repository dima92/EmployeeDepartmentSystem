using Dal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Core.EF
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BGCMIN4;Database=SystemEmpDeptDB;Trusted_Connection=True;");
        }
    }
}
