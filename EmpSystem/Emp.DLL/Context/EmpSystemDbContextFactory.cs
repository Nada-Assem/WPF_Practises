using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Emp.DLL.Context
{
    public class EmpSystemDbContextFactory : IDesignTimeDbContextFactory<EmpSystemDbContext>
    {
        public EmpSystemDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<EmpSystemDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EmpSystemDbContext(optionsBuilder.Options);
        }
    }
}
