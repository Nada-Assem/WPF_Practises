using Emp.DLL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Config
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(E => E.Salary)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(E => E.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(E => E.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}