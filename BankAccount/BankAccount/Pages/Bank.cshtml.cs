using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankAccount.Model;

namespace BankAccount.Pages
{
    public class BankModel : PageModel
    {
        public static List<Bank> bankList = new List<Bank>();
        public void OnGet()
        {
            if(bankList.Count == 0)
            {
                Bank b1 = new Bank() { id = 1, name = "Jyske bank" };
                Bank b2 = new Bank() { id = 2, name = "Sparbank" };
                Bank b3 = new Bank() { id = 3, name = "Danske bank" };
                bankList.Add(b1);
                bankList.Add(b2);
                bankList.Add(b3);
            }
        }
    }
}
