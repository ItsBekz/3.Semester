using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace HouseAndWindowsRazor.Pages
{
    public class HousesModel : PageModel
    {
        public static List<House> listHouses { get; set; }
        public House currentHouse;
        public static List<Window> listWindows { get; set; }
        public void OnGet()
        {
            if(listWindows == null)
            {
                listWindows = new List<Window>();
            }
            if(currentHouse == null)
            {
                currentHouse = new House();
            }
            if(listHouses == null)
            {
                listHouses = new List<House>();
                House h1 = new House();
                h1.name = "Leonor's House";
                Window w1 = new Window();
                w1.name = "Small window";
                w1.value = 10;
                h1.Windows.Add(w1);
                listHouses.Add(h1);
                House h2 = new House();
                h2.name = "Miguel's House";
                listHouses.Add(h2);
            }
        }

        public void OnPost()
        {
            
        }
    }
}
