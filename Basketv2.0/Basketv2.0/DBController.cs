using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using Basketv2._0.Models;

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
                Console.WriteLine("Succesfully established the SqlConnection");
                return connection;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Product> GetProducts()
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
                Console.WriteLine("Succesfully gathered a list of the products in the database");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            finally
            {
                connection.Dispose();
            }

            return listProducts;
        }

        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            SqlConnection connection = GetConnection();
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
                Console.WriteLine("Succesfully gathered a list of the Users in the database");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Dispose();
            }
            return userList;
        }

        public List<Basket> UsersBasket(User user)
        {
            List<Basket> userBasket = new List<Basket>();
            SqlConnection connection = GetConnection();
            try
            {
                using (connection) 
                {
                    connection.Open();
                    string query = "SELECT u.ID, b.* FROM Users u INNER JOIN Basket b ON u.ID = b.UserID WHERE u.ID = @id;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", user.id);
                        command.ExecuteNonQuery();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Basket basket = new Basket();
                                basket.id = reader.GetInt32(1);
                                basket.productId = reader.GetInt32(2);
                                basket.userId = reader.GetInt32(3);
                                userBasket.Add(basket);
                            }
                        }
                    }
                }
                Console.WriteLine("Succesfully found the users basket");
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Dispose();
            }
            return userBasket;
        }
        
        public void BuyProduct(User user, Product product)
        {
            SqlConnection connection = GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "INSERT INTO Basket (ProductID, UserID) VALUES (@productId, @userId);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", product.id);
                        command.Parameters.AddWithValue("@userId", user.id);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Succesfully added something to users basket");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Dispose();
            }
        }
        
        public void AddNewUser(string username, string password)
        {
            SqlConnection connection = GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, Password) VALUES (@username, @password);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Succesfully added a new user");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public bool CheckUser(string username, string password)
        {
            bool check = false;
            List<User> userList = GetUsers();

            check = userList.Any(x => x.username == username);

            return check;
        }
    }
}
