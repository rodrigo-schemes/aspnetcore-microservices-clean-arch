using System.Reflection;
using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var checkProducts = productCollection.Find(b => true).Any();
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, 
            "Data", "SeedData", "products.json");

        if (!checkProducts)
        {
            var productsData = File.ReadAllText(path);
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            productCollection.InsertManyAsync(products);
        }
    }
}