using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Enities
{
    public class Deparment : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
