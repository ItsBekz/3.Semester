using Basketv2._0.Models;
using System.Text;

namespace Basketv2._0
{
    public class HTMLBuilder
    {
        public string GenerateProductHtml(List<Product> listProducts)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<html> <head> <title>Products</title> </head> <body> <h1>Products</h1> <br> <table> <tr>");

            foreach (Product product in listProducts)
            {
                htmlBuilder.Append("<form action=\"/basket\" method=\"POST\">");
                htmlBuilder.Append("<th style=\"width:100px;\"> <div> <img src=\"/images/");
                htmlBuilder.Append(product.img);
                htmlBuilder.Append("\" width=\"100px\"/><label>");
                htmlBuilder.Append(product.name);
                htmlBuilder.Append("</label><button name=\"" + product.id + "\" type=\"submit\" value=\"" + product.name + "\">Buy</button> </div> </th> </form>");
            }

            htmlBuilder.Append("</tr> </table> </body> </html>");

            return htmlBuilder.ToString();

        }

        public string GenerateBasketHtml(List<Basket> listBasket)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<html> <head> <title>Basket</title> </head> <body> <h2>Basket</h2> </body> </html>");

            return htmlBuilder.ToString();
            
        }
    }
}
