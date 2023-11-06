using api.Controllers.Services;
using api.Controllers.Services.Interfaces;
using api.Data;
using api.Data.Interface;
using api.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using api.Data.Repos;

namespace api
{
    // Connects the Interfaces with it's classes so that whenever a Interface is called it uses the methods defined in that class
    // Meaning you can always replace the class with another as long as it uses that Interface.
    // This let's you exchane your code out easily if you make major changes
    static public class ServicesRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Services
            services.AddScoped<ICustomerService, CustomerService>();

            // Repos
            services.AddScoped<ICustomerRepo, CustomerRepo>();
        }

    }
}
