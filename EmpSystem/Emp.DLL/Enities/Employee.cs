using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Enities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public Deparment Department { get; set; }
    }
}
