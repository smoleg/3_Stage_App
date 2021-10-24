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
        public ObservableCollection<Department> DepartmentList { get; set; }
        public DepartmentDatabase()
        {
            DepartmentList = new ObservableCollection<Department>();
            FilldepList();
        }

        private void FilldepList()
        {
            DepartmentList.Add(Department.HR);
            DepartmentList.Add(Department.IT);
            DepartmentList.Add(Department.RnD);
            DepartmentList.Add(Department.None);
            DepartmentList.Add(Department.Sales);
            DepartmentList.Add(Department.Transport);
            DepartmentList.Add(Department.Production);
            DepartmentList.Add(Department.Storage);
            DepartmentList.Add(Department.Managment);
            DepartmentList.Add(Department.Security);
        }
    }
}
