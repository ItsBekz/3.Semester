using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankAccount.Model;
using System.Security.Principal;

namespace BankAccount.Pages
{
    public class AccountModel : PageModel
    {
        public Bank? myBank { get; set; }
        public void OnGet()
        {

        }

        public void OnGetAccount(int id)
        {
            myBank = BankModel.bankList.Find(x => x.id == id);
            // set the h1 to be the bank name
            ViewData["bankName"] = myBank.name;
        }
    }
}
