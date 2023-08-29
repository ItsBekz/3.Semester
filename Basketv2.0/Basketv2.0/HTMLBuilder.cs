using Basketv2._0.Models;
using System.Text;

namespace Basketv2._0
{
    public class HTMLBuilder
    {
        public string GenerateProductHtml(List<Product> listProducts)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<h1 align=\"center\">Store</h1> <br>");
            htmlBuilder.Append("<form action=\"/basket\" method=\"POST\">");
            htmlBuilder.Append("<button type=\"submit\" id=\"goToBasket\" name=\"goToBasket\" align=\"right\" width=\"100px\" height=\"20\">Go to my Basket</button>");
            htmlBuilder.Append("</form>");
            htmlBuilder.Append("<table> <tr>");

            foreach (Product product in listProducts)
            {
                htmlBuilder.Append("<form action=\"/basket\" method=\"POST\">");
                htmlBuilder.Append("<div style=\"width:150;\"> <td align=\"center\" style=\"padding:2px 10px\"> <img src=\"/images/");
                htmlBuilder.Append(product.img);
                htmlBuilder.Append("\" width=\"100px\"/>");
                htmlBuilder.Append("<br><label style=\"padding:4px 0px;\">");
                htmlBuilder.Append(product.name);
                htmlBuilder.Append("</label>");
                htmlBuilder.Append("<br> <button name=\"" + product.id + "\" type=\"submit\" value=\"" + product.name + "\">Buy</button>");
                htmlBuilder.Append("<br> <input type=\"hidden\" id=\"Btn\" name=\"Btn\" value=\"" + product.name + "\"/> </td> </div> </form>");
            }

            htmlBuilder.Append("</tr> </table>");
            htmlBuilder.Append("</body> </html>");
            htmlBuilder.Append("</body> </html>");
            
            return htmlBuilder.ToString();
        }


        public string GenerateBasketHtml(List<Basket> userBasket, User user, DBController dBController)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            int totalPrice = 0;

            htmlBuilder.Append("<html> <head> <title>Basket</title> </head> <body> <h2>Basket</h2> <br>");
            htmlBuilder.Append("<p>UserID = " + user.id + "</p>");
            htmlBuilder.Append("<table> <tr> <th style=\"width:150px;\" align=\"left\">Product</th> <th style=\"width:100px;\">Price</th> </tr>");
            foreach(Basket boughtProduct in userBasket)
            {
                htmlBuilder.Append("<tr> <td align=\"left\">" + FindProduct(boughtProduct, dBController).name + "</td>");
                htmlBuilder.Append("<td align=\"center\">" + FindProduct(boughtProduct, dBController).price + "</td> </tr>");
                totalPrice += FindProduct(boughtProduct, dBController).price;
            }
            htmlBuilder.Append("<tr> <td align=\"left\" style=\"font-weight: bold;\">Total</td>");
            htmlBuilder.Append("<td align=\"center\" style=\"font-weight: bold;\">" + totalPrice + "</td> </tr>");

            htmlBuilder.Append("</table>");
            htmlBuilder.Append("<form action=\"/products\" method=\"POST\">");
            htmlBuilder.Append("<button type=\"submit\" id=\"goToProducts\" name=\"goToProducts\" width=\"100px\" height=\"20\">Buy more Products</button>");
            htmlBuilder.Append("</body> </html>");
            

            return htmlBuilder.ToString();
        }


        public Product FindProduct(Basket basket, DBController dBController)
        {
            Product product = new Product();
            product = dBController.GetProducts().Find(x => x.id == basket.productId);
            return product;
        }
    }
}
