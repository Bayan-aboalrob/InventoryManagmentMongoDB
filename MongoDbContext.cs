using MongoDB.Driver;
using System;
namespace InventoryManagmentMongoDB
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");
        public IMongoCollection<InventoryItem> Inventory => _database.GetCollection<InventoryItem>("Inventory");
    }
}
