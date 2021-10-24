using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data
{
    public class Person
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public Department Department { get; set; } = Department.None;

        public int Salary { get; set; }

        public Person() { }

        public Person(string FN, string SN, string LN, Department dep, int Inc)
        {
            FirstName = FN;
            SecondName = SN;
            LastName = LN;
            Department = dep;
            Salary = Inc;
        }
    }
}
