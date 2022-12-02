using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_ST10084795_ClassLibrary
{
    public class DayAside
    {
        public void GetSetAsideDay()
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=aspnet-POE3-53bc9b9d-9d6a-45d4-8429-2a2761773502;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM SetAsideDay" +
                        "WHERE CAST(DaySetAside AS DATE) = CAST(GETDATE() AS DATE)";
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
