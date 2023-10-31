using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    // Connection with the Database
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
        public DbSet<Customers> Customers { get; set; }
    }
}
