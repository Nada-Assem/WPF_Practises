using Emp.DLL.Entities;
using Emp.DLL.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Context
{
    public class EmpSystemDbContext : DbContext
    {
        public EmpSystemDbContext(DbContextOptions<EmpSystemDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EmployeeDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpSystemDbContext).Assembly);

            // Define paths to your JSON files
            string departmentsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSeed", "departments.json");
            string employeesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSeed", "employees.json");

            // Load and seed Departments
            var departments = SeedDataHelper.LoadSeedData<Deparment>(departmentsPath);
            modelBuilder.Entity<Deparment>().HasData(departments);

            // Load and seed Employees
            var employees = SeedDataHelper.LoadSeedData<Employee>(employeesPath);
            modelBuilder.Entity<Employee>().HasData(employees);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
    }
}
