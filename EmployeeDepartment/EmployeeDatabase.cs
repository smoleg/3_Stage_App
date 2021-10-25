using EmpDep.Communication.EmpDepService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeDepartment
{
    public class EmployeeDatabase
    {
        private EmpDepServiceSoapClient EmpDepServiceSoapClient = new EmpDepServiceSoapClient();
        public ObservableCollection<Person> EmployeeList { get; set; }

        public EmployeeDatabase()
        {
            EmployeeList = new ObservableCollection<Person>();
            Load();
        }

        private void Load()
        {
            foreach (var emp in EmpDepServiceSoapClient.Load())
                EmployeeList.Add(emp);
        }

        public int Add(Person employee)
        {
            var res = EmpDepServiceSoapClient.Add(employee);
            if (res > 0)
                EmployeeList.Add(employee);
            return res;
        }

        public int Update(Person employee)
        {
            return EmpDepServiceSoapClient.Update(employee);
        }

        public int Remove(Person employee)
        {
            var res = EmpDepServiceSoapClient.Add(employee);
            if (res > 0)
                EmployeeList.Remove(employee);
            return res;
        }
    }
}
