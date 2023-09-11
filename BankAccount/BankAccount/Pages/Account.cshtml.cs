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

        public void OnPostCreate()
        {
            // get the account owner and balance from the form
            string? owner = Request.Form["accountOwner"];
            double? balance = double.Parse(Request.Form["balance"]);
            // get the bank id from the form
            int bankId = int.Parse(Request.Form["bankId"]);
            // find the bank in the bankList
            Bank? myBank = BankModel.bankList.Find(x => x.id == bankId);
            // create a new account
            Account? newAccount = new Account() { owner = owner, balance = balance };
            // add the new account to the bank
            myBank.accountList.Add(newAccount);
        }
    }
}
