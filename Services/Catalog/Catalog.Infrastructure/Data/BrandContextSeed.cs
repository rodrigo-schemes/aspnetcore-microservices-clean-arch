using System.Reflection;
using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
    {
        var checkBrands = brandCollection.Find(b => true).Any();
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, 
            "Data", "SeedData", "brands.json");

        if (!checkBrands)
        {
            var brandsData = File.ReadAllText(path);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            brandCollection.InsertManyAsync(brands);
        }
    }
}