using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Context
{
    public class EmpSystemDbContextFactory : IDesignTimeDbContextFactory<EmpSystemDbContext>
    {
        public EmpSystemDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmpSystemDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=EmployeeDB;Trusted_Connection=True;");

            return new EmpSystemDbContext(optionsBuilder.Options);
        }
    }
}
