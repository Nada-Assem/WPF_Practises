using System;
using System.Windows;
using System.Windows.Controls;
using Emp.BLL.Interfaces;
using Emp.DLL.Entities;

namespace EmpSystem
{
    public partial class EmployeeWindow : Window
    {
        private readonly IGenericService<Employee> _employeeService;
        private readonly IGenericService<Deparment> _departmentService;

        public EmployeeWindow(IGenericService<Employee> employeeService, IGenericService<Deparment> departmentService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _departmentService = departmentService;
            LoadData();
        }

        private async void LoadData()
        {
            var employees = await _employeeService.GetAllAsync();
            EmployeeDataGrid.ItemsSource = employees;

            var departments = await _departmentService.GetAllAsync();
            DepartmentComboBox.ItemsSource = departments;
            DepartmentComboBox.DisplayMemberPath = "Name";
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                // Populate the fields with the selected employee's data
                EmployeeNameTextBox.Text = selectedEmployee.Name;
                SalaryTextBox.Text = selectedEmployee.Salary.ToString();
                HireDatePicker.SelectedDate = selectedEmployee.HireDate;

                // Set the selected department in the ComboBox
                DepartmentComboBox.SelectedItem = selectedEmployee.Department;
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newEmployee = new Employee
            {
                Name = EmployeeNameTextBox.Text,
                Salary = decimal.TryParse(SalaryTextBox.Text, out var salary) ? salary : 0,
                HireDate = HireDatePicker.SelectedDate ?? DateTime.Now,
                Department = (Deparment)DepartmentComboBox.SelectedItem
            };

            await _employeeService.AddAsync(newEmployee);
            LoadData();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                selectedEmployee.Name = EmployeeNameTextBox.Text;
                selectedEmployee.Salary = decimal.TryParse(SalaryTextBox.Text, out var salary) ? salary : selectedEmployee.Salary;
                selectedEmployee.HireDate = HireDatePicker.SelectedDate ?? selectedEmployee.HireDate;
                selectedEmployee.Department = (Deparment)DepartmentComboBox.SelectedItem;

                await _employeeService.UpdateAsync(selectedEmployee);
                LoadData();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                await _employeeService.DeleteAsync(selectedEmployee.ID);
                LoadData();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
