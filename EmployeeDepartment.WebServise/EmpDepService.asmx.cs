using Employee.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EmployeeDepartment.WebServise
{
    /// <summary>
    /// Summary description for EmpDepService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmpDepService : System.Web.Services.WebService
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["EmpDepConnectionString"].ConnectionString;


        [WebMethod]
        public ObservableCollection<Person> Load()
        {
            ObservableCollection<Person> employees = new ObservableCollection<Person>();
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
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        [WebMethod]
        public int Add(Person employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                employee.ID = GenerateID();
                string sqlExpression = $@"INSERT INTO Employees (ID, FirstName, SecondName, LastName, Salary, DepID)
                                     VALUES ( '{employee.ID}', '{employee.FirstName}', '{employee.SecondName}',
                                              '{employee.LastName}', '{employee.Salary}',{(int)employee.Department} )";
                var command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteNonQuery();
                return res;
            }
        }

        private int GenerateID()
        {
            Random random = new Random();
            return Math.Abs(random.Next(1, 1000000000) * random.Next(1, 12451) / random.Next(1, 150));
        }

        [WebMethod]
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

        [WebMethod]
        public int Remove(Person employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlExpression = $@"DELETE FROM Employees WHERE ID = '{employee.ID}'";
                var command = new SqlCommand(sqlExpression, connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
