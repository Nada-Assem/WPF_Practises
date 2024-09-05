using Emp.BLL.Interfaces;
using Emp.BLL.Services;
using Emp.DLL.Context;
using Emp.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace EmpSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        private IConfiguration configuration;

        public App()
        {
            // Build configuration
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("defaultConnection");

            services.AddDbContext<EmpSystemDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<MainWindow>();
            services.AddTransient<EmployeeWindow>();

            services.AddScoped<IGenericService<Employee>, EmployeeService>();
            services.AddScoped<IGenericService<Deparment>, DepartmentService>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
