using Microsoft.EntityFrameworkCore;
using RashutSdotHateufa.Models;
using System.Collections.Generic;

namespace RashutSdotHateufa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}
