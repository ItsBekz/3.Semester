using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using ASP.NET_Core_6._0_Basket.Pages;

namespace ASP.NET_Core_6._0_Basket
{
    public class DBController
    {
        private readonly IConfiguration _configuration;

        public SqlConnection GetConnection() 
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return connection;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void GetProducts()
        {
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
                                ProductInfo productInfo = new ProductInfo();
                                productInfo.id = reader.GetInt32(0);
                                productInfo.name = reader.GetString(1);
                                productInfo.description = reader.GetString(2);
                                productInfo.price = reader.GetInt32(3);

                                ProductsModel.listProducts.Add(productInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return;
            }
            finally
            {
                connection.Dispose();
            }
        }
        
    }
}
