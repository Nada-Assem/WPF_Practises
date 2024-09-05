using Emp.BLL.Interfaces;
using Emp.BLL.Services;
using Emp.DLL.Context;
using Emp.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmpSystem
{

    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<EmpSystemDbContext>(options =>
                options.UseSqlServer("Server=.;Database=EmployeeDB;Trusted_Connection=True;"));
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            LoadEmployeeWindowAsync();
        }

        private async void LoadEmployeeWindowAsync()
        {
            await Task.Delay(3000);
            var employeeWindow = _serviceProvider.GetRequiredService<EmployeeWindow>();
            employeeWindow.Show();
            this.Close();
        }
    }
}   