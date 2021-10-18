using Employee.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartment
{
    class DepartmentDatabase
    {
        //public ObservableCollection
        public List<Department> DepartmentList { get; set; }
        public DepartmentDatabase()
        {
            DepartmentList = new List<Department>();
            DepartmentList.AddRange(Enum.GetValues(typeof(Department)).Cast<Department>());
        }
    }
}
