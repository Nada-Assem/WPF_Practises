using Emp.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Config
{
    internal class DepartmentConfigrations : IEntityTypeConfiguration<Deparment>
    {
        public void Configure(EntityTypeBuilder<Deparment> builder)
        {
            builder.Property(D => D.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
