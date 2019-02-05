using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppEmpDep.Models
{
    /// <summary>
    /// Класс для работы с БД по списку Департаментов
    /// </summary>
    public class DataDep
    {
        private SqlConnection sqlConnection;

        public DataDep()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                         Initial Catalog=Emp_Dep;
                                         Integrated Security=True";

            sqlConnection   =   new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        /// <summary>
        /// Метод получения списка Департаментов из БД
        /// </summary>
        /// <returns></returns>
        public List<Department> GetList()
        {
            List<Department> list = new List<Department>();

            string sql = @"SELECT * FROM DepTable";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add( 
                        new Department()
                        {
                            DepId = (int) reader["Id"], 
                            DepName = reader["NameDep"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Метод получения Департамента по номеру из БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepById(int id)
        {
            string sql = $@"SELECT * FROM DepTable WHERE Id={id}";
            Department temp = new Department();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        temp = new Department()
                        {
                            DepId = (int)reader["Id"],
                            DepName = reader["NameDep"].ToString()
                        };
                    }
                }

            }
            return temp;
        }

        /// <summary>
        /// Метод добавления Департамента в БД
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public bool AddDep(Department dep)
        {
            try
            {
                string sqlAdd = $@" INSERT INTO DepTable(Id, NameDep)
                               VALUES(N'{dep.DepId}',
                                      N'{dep.DepName}') ";
                using (var com = new SqlCommand(sqlAdd, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}