using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.ProductFactories.Any())
        {
            var factoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/Factory.json");
            var factory = JsonSerializer.Deserialize<List<ProductFactory>>(factoriesData);
            context.ProductFactories.AddRange(factory);
        }
        if (!context.ProductCategories.Any())
        {
            var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/Category.json");
            var category = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
            context.ProductCategories.AddRange(category);
        }
        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/Products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(products);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
}
