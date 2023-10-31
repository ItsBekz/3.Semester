using api.Models;

namespace api.Controllers.Services.Interfaces
{
    public interface ICustomerService
    {
        Customers CreateCustomer(string name, string lastName);
        void DeleteCustomerById(int id);
        IEnumerable<Customers> GetAllCustomers();
        Customers GetCustomerById(int id);
    }
}