using api.Controllers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers
{
    // We use the Service here, so that we can call simple methods we need, and don't have too much code inside out controller.
    // Since our controller should only be making the call and not all the background work
    // The controller calls the customerservice(Boss) who then calls UnitOfWork(Manager) which delegate the work to the necessary workers
    // Who then do all the background work we need done.
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customers))]
        public IActionResult GetCustomers()
        {
            var customerList = _customerService.GetAllCustomers();
            return Ok(customerList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customers))]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customers))]
        public IActionResult CustomerCreated(Customers customer)
        {
            var newCustomer = _customerService.CreateCustomer(customer.Name, customer.LastName);
            return Ok(newCustomer);
        }

        [HttpGet("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customers))]
        public IActionResult DeleteCustomerById(int id)
        {
            _customerService.DeleteCustomerById(id);
            return Ok();
        }
    }
}
