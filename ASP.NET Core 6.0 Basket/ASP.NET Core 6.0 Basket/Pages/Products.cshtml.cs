using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ASP.NET_Core_6._0_Basket.Pages
{
    public class ProductsModel : PageModel
    {
        public static List<ProductInfo> listProducts = new List<ProductInfo>();
        public void OnGet()
        {
            DBController DBController = new DBController();
            DBController.GetProducts();
        }
    }

    public class ProductInfo
    {
        public int id;
        public string name;
        public string description;
        public int price;
    }
}
