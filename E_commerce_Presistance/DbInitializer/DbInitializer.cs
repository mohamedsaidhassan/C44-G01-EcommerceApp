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

namespace E_commerce_Presistance.Dbinitializer
{
    public class DbInitializer(ApplicationContext appdbContext): IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                if ((await appdbContext.Database.GetPendingMigrationsAsync()).Any())
                    await appdbContext.Database.MigrateAsync();

                if (!(appdbContext.Brands.Any()))
                {
                    var path = Path.Combine(
                              Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
                              "E_commerce_Presistance",
                              "DataSeed",
                              "brands.json"
                          );

                    var BrandData = await File.ReadAllTextAsync(path);
                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);

                    if (Brands != null && Brands.Any())
                    {
                        appdbContext.Brands.AddRange(Brands);
                        await appdbContext.SaveChangesAsync();
                    }


                }



                if (!(appdbContext.ProductTypes.Any()))
                {
                    var path = Path.Combine(
                              Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
                              "E_commerce_Presistance",
                              "DataSeed",
                              "types.json"
                          );

                    var ProuductsTypesdata = await File.ReadAllTextAsync(path);
                    var types = JsonSerializer.Deserialize<List<ProductType>>(ProuductsTypesdata);

                    if (types != null && types.Any())
                    {


                        appdbContext.ProductTypes.AddRange(types);
                        await appdbContext.SaveChangesAsync();

                    }


                }

                if (!(appdbContext.Products.Any()))
                {
                    var path = Path.Combine(
                              Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
                              "E_commerce_Presistance",
                              "DataSeed",
                              "products.json"
                          );

                    var ProuductData = await File.ReadAllTextAsync(path);
                    var products = JsonSerializer.Deserialize<List<Product>>(ProuductData);

                    if (products != null && products.Any())
                    {
                        appdbContext.Products.AddRange(products);
                        await appdbContext.SaveChangesAsync();

                    }


                }

            }
            catch (Exception )
            {
                throw;
            }

        }

    }
}
