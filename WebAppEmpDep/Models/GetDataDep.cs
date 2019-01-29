using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppEmpDep.Models
{
    public class GetDataDep
    {
        private SqlConnection sqlConnection;

        public GetDataDep()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                         Initial Catalog=Emp_Dep;
                                         Integrated Security=True";

            sqlConnection   =   new SqlConnection(connectionString);
            sqlConnection.Open();
        }

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

        public Department GetDepById(int Id)
        {
            string sql = $@"SELECT * FROM DepTable WHERE Id={Id}";
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

        public bool AddDep(Department Dep)
        {
            try
            {
                string sqlAdd = $@" INSERT INTO DepTable(Id, NameDep)
                               VALUES(N'{Dep.DepId}',
                                      N'{Dep.DepName}') ";
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