namespace BankAccount.Model
{
    public class Bank
    {
        public int id { get; set; }
        public string? name { get; set; }
        public List<Account>? accountList { get; set; }
    }
}
