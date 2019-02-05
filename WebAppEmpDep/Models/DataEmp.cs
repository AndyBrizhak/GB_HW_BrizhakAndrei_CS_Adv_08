using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppEmpDep.Models
{
    /// <summary>
    /// Класс для работы с БД по списку Работников
    /// </summary>
    public class DataEmp
    {
        private SqlConnection sqlConnection;

        public DataEmp()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                         Initial Catalog=Emp_Dep;
                                         Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }


        /// <summary>
        /// Метод получения списка  Работников из БД
        /// </summary>
        /// <returns></returns>
        public List<Employee> Get()
        {
            List<Employee> list = new List<Employee>();

            string sql = @"SELECT * FROM EmpTable";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(
                            REmp(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Метод чтения из БД Работника
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Employee REmp(SqlDataReader reader)
        {
            return new Employee()
            {
                Id = (int)reader["Id"],
                FName = reader["FName"].ToString(),
                LName = reader["LName"].ToString(),
                Age = reader["Age"].ToString(),
                DepId = (int)reader["DepId"]
            };
        }

        /// <summary>
        /// Метод получения Работника по номеру из БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee Get(int id)
        {
            string sql = $@"SELECT * FROM EmpTable WHERE Id={id}";
            var temp = new Employee();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp = REmp(reader);
                    }
                }

            }
            return temp;
        }

    }
}