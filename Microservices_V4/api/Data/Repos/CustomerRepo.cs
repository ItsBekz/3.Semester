using api.Data.Repos.Interfaces;
using api.Models;

namespace api.Data.Repos
{
    // Calls all the CRUD commands you want
    // Make Error checks and so on here too
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerDbContext _context;

        public CustomerRepo(CustomerDbContext context)
        {
            _context = context;
        }

        // CRUD
        public Customers CreateCustomer(Customers customer)
        {
            // Since we use Encore we can just use Add directly instead of calling the SQL Queries
            _context.Customers.Add(customer);

            return customer;
        }

        // Gets all customers
        public IEnumerable<Customers> GetCustomers()
        {
            var customers = _context.Customers;

            return customers;
        }

        // Get Customer by Id
        public Customers GetCustomersById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            return customer;
        }

        public void DeleteCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            _context.Customers.Remove(customer);
        }
    }
}
