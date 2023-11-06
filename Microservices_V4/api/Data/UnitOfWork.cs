using api.Data.Interface;
using api.Data.Repos.Interfaces;

namespace api.Data
{
    // Unit of work calls the CustomerRepo and the DbContext
    // Unit of Work is like a manager that has access to all the different workers(CustomerRepo)
    public class UnitOfWork : IUnitOfWork
    {
        private CustomerDbContext _context;

        public ICustomerRepo CustomerRepo { get; private set; }

        public UnitOfWork(CustomerDbContext context, ICustomerRepo customerRepo)
        {
            _context = context;

            CustomerRepo = customerRepo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
