using E_commerce_Presistance.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using E_commerce_Presistance.Dbinitializer;
using E_Commerce_Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using E_commerce_Presistance.Repositories;
using E_Commerce_service_Abstraction.Service;
using E_commerce_Presistance.Services;

namespace E_commerce_Presistance.DependancyInjection
{
    public static class PresistanceServiceExtensions
    {
         public static IServiceCollection AddPresistanceService(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddScoped<IBasketRepo, BasketRepository>();
            services.AddScoped<ICashService,CashService>();
            services.AddSingleton<IConnectionMultiplexer>(
                cfg => 
                {
                    return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
                }

                );

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
