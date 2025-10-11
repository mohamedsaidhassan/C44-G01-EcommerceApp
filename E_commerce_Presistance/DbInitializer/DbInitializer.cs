using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Domain;
using E_Commerce_Domain.Entities.Products;
using E_Commerce_Domain.Contracts;
using E_commerce_Presistance.Context;
using System.Text.Json;

namespace E_commerce_Presistance.DbInitializer
{
    internal class DbInitializer(ApplicationContext appdbContext): IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                if ((await appdbContext.Database.GetPendingMigrationsAsync()).Any())
                    await appdbContext.Database.MigrateAsync();

                if (!(appdbContext.Brands.Any()))
                {
                    var BrandData = await File.ReadAllTextAsync("E_commerce_Presistance\\DataSeed\\brands.json");
                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);

                    if (Brands != null && Brands.Any())
                    {
                        appdbContext.Brands.AddRange(Brands);
                    }
                    await appdbContext.SaveChangesAsync();

                }
            }
            catch (Exception )
            {
                throw;
            }

        }

    }
}
