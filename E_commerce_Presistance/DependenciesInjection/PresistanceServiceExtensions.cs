using E_commerce_Presistance.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using E_commerce_Presistance.Dbinitializer;
using E_Commerce_Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_Presistance.DependancyInjection
{
    public static class PresistanceServiceExtensions
    {
         public static IServiceCollection AddPresistanceService(this IServiceCollection services,
             IConfiguration configuration)
        {
           services.AddDbContext<ApplicationContext>(option =>
            {
                var connection = configuration.GetConnectionString("DefaultConnection");
                option.UseSqlServer(connection);
            });

           // Register db initializer
           services.AddScoped<IDbInitializer,DbInitializer>();

           return services;
        }
    }
}
