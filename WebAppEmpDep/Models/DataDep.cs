using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppEmpDep.Models
{
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

        public List<Department> GeList()
        {
            List<Department>    list = new List<Department>();
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
                                DepId = reader["Id"]),
                                DepName = reader["NameDep"].ToString()
                            });
                    }
                }

            }
        }


    }
}