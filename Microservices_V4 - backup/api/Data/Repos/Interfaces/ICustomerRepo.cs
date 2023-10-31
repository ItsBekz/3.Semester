using api.Models;

namespace api.Data.Repos.Interfaces
{
    public interface ICustomerRepo
    {
        Customers CreateCustomer(Customers customer);
        void DeleteCustomerById(int id);
        IEnumerable<Customers> GetCustomers();
        Customers GetCustomersById(int id);
    }
}