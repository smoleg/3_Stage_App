using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Data;

namespace EmployeeDepartment
{
    public class EmployeeDatabase
    {
        private static int CHAR_BOUND_L = 65; 
        private static int CHAR_BOUND_H = 90; 

        private Random random = new Random();
        public ObservableCollection<Person> EmployeeList { get; set; }

        public EmployeeDatabase()
        {
            EmployeeList = new ObservableCollection<Person>();
            GenerateEmployees(20);
        }

        public string GenerateSymbols(int amount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < amount; i++)
                stringBuilder.Append((char)(CHAR_BOUND_L + random.Next(CHAR_BOUND_H - CHAR_BOUND_L)));
            return stringBuilder.ToString();
        }

        private void GenerateEmployees(int empCount)
        {
            EmployeeList.Clear();

            string firstName;
            string lastName;
            string secondName;
            Department department;
            int salary;

            for (int i = 0; i < empCount; i++)
            {
                firstName = GenerateSymbols(random.Next(6) + 5);
                secondName = GenerateSymbols(random.Next(6) + 5);
                lastName = GenerateSymbols(random.Next(6) + 5);                
                department = (Department)random.Next(6);
                salary = random.Next(10, 200) * 1000;

                EmployeeList.Add(new Person(firstName, secondName, lastName, department, salary));
            }
        }
    }
}
