using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private DatabaseSettings _databaseSettings;

        public CatalogContext(IConfiguration configuration)
        {
            _databaseSettings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            Products = database.GetCollection<Product>(_databaseSettings.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
