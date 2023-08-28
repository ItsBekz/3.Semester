using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor1.Models;

namespace Razor1.Pages
{
    public class CatModel : PageModel
    {
        [BindProperty]
        public Cat currentCat { get; set; }
        public static List<Cat> cats = new List<Cat>();

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            cats.Add(currentCat);   
        }
    }
}
