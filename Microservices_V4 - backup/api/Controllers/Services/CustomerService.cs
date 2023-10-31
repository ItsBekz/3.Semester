using api.Controllers.Services.Interfaces;
using api.Data.Interface;
using api.Models;

namespace api.Controllers.Services
{
    public class CustomerService : ICustomerService
    {
        // Gets called from Controller.
        // Calls the UnitOfWork
        // _ in front = private variable
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IUnitOfWork unitOfWork, ILogger<CustomerService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // creates the customer
        public Customers CreateCustomer(string name, string lastName)
        {
            Customers customer = new Customers()
            {
                Name = name,
                LastName = lastName
            };

            _unitOfWork.CustomerRepo.CreateCustomer(customer);
            _unitOfWork.Save();

            return customer;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            var customerList = _unitOfWork.CustomerRepo.GetCustomers();

            return customerList;
        }

        public Customers GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepo.GetCustomersById(id);

            return customer;
        }

        public void DeleteCustomerById(int id)
        {
            _unitOfWork.CustomerRepo.DeleteCustomerById(id);
            _unitOfWork.Save();
        }
    }
}
