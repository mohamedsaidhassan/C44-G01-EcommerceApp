using E_commerce_Presistance.DependancyInjection;
using E_Commerce_Domain.Contracts;
using System.Threading.Tasks;
using E_Commerce_Service.Dependancyinjection;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;
using E_Commerce_Presentation.API.Controllers;
using E_commerce_Presistance.Dbinitializer;
namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
         

            builder.Services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);

            builder.Services.ApplicationServices();
            builder.Services.AddPresistanceService(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var scope = app.Services.CreateScope();

            // var intializer = app.Services.GetRequiredService<IDbInitializer>();
            var intializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await intializer.InitializeAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
