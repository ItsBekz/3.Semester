using api.Controllers.Services;
using api.Controllers.Services.Interfaces;
using api.Data;
using api.Data.Interface;
using api.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using api.Data.Repos;

namespace api
{
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
