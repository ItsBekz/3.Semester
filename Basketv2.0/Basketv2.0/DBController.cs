using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Basketv2._0
{
    public class DBController
    {
        public SqlConnection GetConnection() 
        {
            try
            {
                string connStr = "Data Source=mssql13.unoeuro.com;Initial Catalog=lightsandbox_dk_db_mssql;Persist Security Info=True;User ID=lightsandbox_dk;Password=yAzp3ndRxegcDrHkhafm";
                SqlConnection connection = new SqlConnection(connStr);
                return connection;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetProducts()
        {
            List<Product> listProducts = new List<Product>();
            SqlConnection connection = GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "SELECT * FROM Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product productInfo = new Product();
                                productInfo.id = reader.GetInt32(0);
                                productInfo.name = reader.GetString(1);
                                productInfo.description = reader.GetString(2);
                                productInfo.img = reader.GetString(3);
                                productInfo.price = reader.GetInt32(4);

                                listProducts.Add(productInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            finally
            {
                connection.Dispose();
            }

            string html = "<html> <head> <title>Products</title> </head> <body> <h1>Products</h1> <br> <table> <tr> ";
            
            foreach (Product product in listProducts)
            {
                html += "<th style=\"width:100px;\"> <div> <img src=\"../images/" + product.img + "\" width=\"100px\" />" +
                    "<label>" + product.name + "</label>" +
                    "<button id=\"Btn" + product.name + "\">Buy</button> </div> </th> ";
            }
            html += "</tr> </table> </body> </html>";
            return html;
        }

        public bool CheckUser(string username, string password)
        {
            bool check = false;
            SqlConnection connection = GetConnection();
            List<User> userList = new List<User>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "SELECT * FROM Users";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User userInfo = new User();
                                userInfo.id = reader.GetInt32(0);
                                userInfo.username = reader.GetString(1);
                                userInfo.password = reader.GetString(2);
                                userList.Add(userInfo);
                            }
                        }
                    }
                }

                check = userList.Any(x => x.username == username);

            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return check;
        }

        public static 


    }
}
