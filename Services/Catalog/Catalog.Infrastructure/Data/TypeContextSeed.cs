using System.Reflection;
using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> typeCollection)
    {
        var checkTypes = typeCollection.Find(b => true).Any();
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, 
            "Data", "SeedData", "types.json");

        if (!checkTypes)
        {
            var typesData = File.ReadAllText(path);
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            typeCollection.InsertManyAsync(types);
        }
    }
}