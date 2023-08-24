using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ASP.NET_Core_6._0_Basket.Pages.Users
{
    public class CreateModel : PageModel
    {
        public UserListModel ulm = new UserListModel();
        public UserInfo userInfo = new UserInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            userInfo.id = ulm.listUsers.Count() + 1;
            userInfo.username = Request.Form["username"];
            userInfo.password = Request.Form["password"];
            
            if(userInfo.username.Length == 0 || userInfo.password.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                string connectionString = "Data Source=mssql13.unoeuro.com;Initial Catalog=lightsandbox_dk_db_mssql;Persist Security Info=True;User ID=lightsandbox_dk;Password=***********";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users " +
                        "(ID, Username, Password) VALUES " +
                        "(@id, @username, @password);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", userInfo.id);
                        command.Parameters.AddWithValue("@username", userInfo.username);
                        command.Parameters.AddWithValue("@password", userInfo.password);

                        command.ExecuteNonQuery();
                    }
                }
            } 
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            
            userInfo.username = ""; userInfo.password = "";
            successMessage = "New User added!";

            Response.Redirect("../Index");
        }
    }
}
