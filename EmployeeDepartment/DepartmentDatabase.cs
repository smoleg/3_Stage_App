using Employee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartment
{
    class DepartmentDatabase
    {
        public List<Department> DepartmentList { get; set; }
        public DepartmentDatabase()
        {
            DepartmentList = new List<Department>();
            DepartmentList.AddRange(Enum.GetValues(typeof(Department)).Cast<Department>());
        }
    }
}
