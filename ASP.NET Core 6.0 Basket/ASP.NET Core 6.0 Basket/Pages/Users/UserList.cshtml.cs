using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_Core_6._0_Basket.Pages.Users
{
    public class UserListModel : PageModel
    {
        public List<UserInfo> listUsers = new List<UserInfo>();
        public void OnGet() //executes when you access the page
        {
            string connectionString = "Data Source=mssql13.unoeuro.com;Initial Catalog=lightsandbox_dk_db_mssql;User ID=lightsandbox_dk;Password=yAzp3ndRxegcDrHkhafm";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "SELECT * FROM Users";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserInfo userInfo = new UserInfo();
                                userInfo.id = reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);

                                listUsers.Add(userInfo);
                            }
                        }
                    }
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            finally
            {
                connection.Dispose();
                
            }
        }
    }

    public class UserInfo
    {
        public int id;
        public string username;
        public string password;
    }
}
