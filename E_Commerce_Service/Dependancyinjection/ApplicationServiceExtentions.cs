using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_service_Abstraction;
using E_Commerce_service_Abstraction.Service;
using E_Commerce_Service.Services;
using System.Reflection;
using E_commerce_Presistance.Repositories;
using E_commerce_Presistance.Dbinitializer;

namespace E_Commerce_Service.Dependancyinjection
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUintofwork,Uintofwork>();
            services.AddScoped<IBasketService,BasketService>();
            services.AddScoped<IProductService, ProductService>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
