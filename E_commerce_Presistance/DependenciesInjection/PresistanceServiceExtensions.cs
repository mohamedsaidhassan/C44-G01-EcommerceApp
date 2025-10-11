using E_commerce_Presistance.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_commerce_Presistance.DependancyInjection
{
    public static class PresistanceServiceExtensions
    {
         public static IServiceCollection AddPresistanceService(this IServiceCollection services,
             IConfiguration configuration)
        {
           return services.AddDbContext<ApplicationContext>(option =>
            {
                var connection = configuration.GetConnectionString("DefaultConnection");

                option.UseSqlServer(connection);
            });
        }
    }
}
