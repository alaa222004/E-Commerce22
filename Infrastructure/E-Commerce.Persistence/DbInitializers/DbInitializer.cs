using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_Commerce.Persistence.DbInitializers
{
    internal class DbInitializer(ApplicationDBContext dBContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            if ((await dBContext.Database.GetPendingMigrationsAsync()).Any())

                await dBContext.Database.MigrateAsync();

            if (!await dBContext.ProductBrands.AnyAsync())
            {
                //Read as json
                //Deserialize
                //Save to DB

                var brandsData = await File.ReadAllTextAsync("../Infrastructure/E-Commerce.Persistence/Context/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                if (brands != null && brands.Any())
                {
                    await dBContext.ProductBrands.AddRangeAsync(brands);
                    await dBContext.SaveChangesAsync();
                }

            }
            if (!await dBContext.ProductTypes.AnyAsync())
            {
                var typesData = await File.ReadAllTextAsync("../Infrastructure/E-Commerce.Persistence/Context/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null && types.Any())
                {
                    await dBContext.ProductTypes.AddRangeAsync(types);
                    await dBContext.SaveChangesAsync();
                }
            }
            if (!await dBContext.Products.AnyAsync())
            {
                var productsData = await File.ReadAllTextAsync("../Infrastructure/E-Commerce.Persistence/Context/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null && products.Any())
                {
                    await dBContext.Products.AddRangeAsync(products);
                    await dBContext.SaveChangesAsync();
                }
            }


        }

    }

}
