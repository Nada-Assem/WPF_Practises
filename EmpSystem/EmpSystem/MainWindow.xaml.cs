using Emp.BLL.Interfaces;
using Emp.BLL.Services;
using Emp.DLL.Context;
using Emp.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace EmpSystem
{
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
