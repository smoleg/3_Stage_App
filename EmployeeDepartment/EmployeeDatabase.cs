using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Data;

namespace EmployeeDepartment
{
    public class EmployeeDatabase
    {
        private const string ConnectionString = "Data Source=EGOR\\SQLEXPRESS;Initial Catalog=EmployeeDepartmentDB;User ID=Root;Password=admin";

        private Random random = new Random();
        public ObservableCollection<Person> EmployeeList { get; set; }

        public EmployeeDatabase()
        {
            EmployeeList = new ObservableCollection<Person>();
            LoadFromDatabase();

        }

        private void LoadFromDatabase()
        {
            string sqlExpression = "SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Person()
                            {
                                ID = reader.GetInt32(0),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader.GetString(1),
                                SecondName = reader["SecondName"].ToString(),
                                Salary = (int)reader["Salary"],
                                Department = (Department)reader.GetInt32(5)
                            };
                            EmployeeList.Add(employee);
                        }
                    }
                }
            }
        }

        public int AddToDatabase(Person employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                employee.ID = Math.Abs(random.Next(1, 1000000000) * random.Next(1, 12451) / random.Next(1, 150));
                connection.Open();

                string sqlExpression = $@"INSERT INTO Employees (ID, FirstName, SecondName, LastName, Salary, DepID)
                                     VALUES ( '{employee.ID}', '{employee.FirstName}', '{employee.SecondName}',
                                              '{employee.LastName}', '{employee.Salary}',{(int)employee.Department} )";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    EmployeeList.Add(employee);
                }
                return res;
            }
        }

        public int Update(Person employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"UPDATE Employees 
                    SET LastName = '{employee.LastName}', FirstName = '{employee.FirstName}', SecondName = '{employee.SecondName}', Salary = '{employee.Salary}', DepID = {(int)employee.Department}
                    WHERE ID = '{employee.ID}'";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }

        public int Remove(Person employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"DELETE FROM Employees WHERE ID = '{employee.ID}'";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    EmployeeList.Remove(employee);
                }
                return res;
            }
        }
    }
}
