using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseAndWindowsRazor.Pages
{
    public class HouseCreateModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            HousesModel.listHouses.Add(new House { name = Request.Form["name"] });
            Response.Redirect("Houses");
        }
    }
}
