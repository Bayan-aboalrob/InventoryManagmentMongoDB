using MongoDB.Driver;

namespace InventoryManagmentMongoDB
{
    public class Database
    {
        private readonly MongoDbContext _context;

        public Database(string connectionString, string databaseName)
        {
            _context = new MongoDbContext(connectionString, databaseName);
        }

        public void AddProduct(Product product)
        {
            var existingProduct = _context.Products.Find(p => p.Name == product.Name).FirstOrDefault();
            if (existingProduct != null)
            {
                throw new System.Exception("A product with the same name already exists.");
            }
            _context.Products.InsertOne(product);
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Find(p => true).ToList();
        }

        public Product FindProductByName(string name)
        {
            return _context.Products.Find(p => p.Name == name).FirstOrDefault();
        }

        public Product FindProductById(string productId)
        {
            return _context.Products.Find(p => p.ProductId == productId).FirstOrDefault();
        }

        public void DeleteProduct(string productId)
        {
            _context.Products.DeleteOne(p => p.ProductId == productId);
            _context.Inventory.DeleteMany(i => i.ProductId == productId);
        }

        public void AddOrUpdateInventoryItem(string productName, int quantity)
        {
            var product = FindProductByName(productName);
            if (product != null)
            {
                var existingItem = _context.Inventory.Find(i => i.ProductId == product.ProductId).FirstOrDefault();
                if (existingItem != null)
                {
                    var update = Builders<InventoryItem>.Update.Inc(i => i.Quantity, quantity);
                    _context.Inventory.UpdateOne(i => i.InventoryId == existingItem.InventoryId, update);
                }
                else
                {
                    var inventoryItem = new InventoryItem(product.ProductId, quantity);
                    _context.Inventory.InsertOne(inventoryItem);
                }
            }
            else
            {
                throw new KeyNotFoundException("Product not found");
            }
        }

        public List<InventoryItem> GetAllInventoryItems()
        {
            return _context.Inventory.Find(i => true).ToList();
        }

        public InventoryItem FindInventoryItem(string productId)
        {
            return _context.Inventory.Find(i => i.ProductId == productId).FirstOrDefault();
        }

        public void EditInventoryItem(string inventoryId, int newQuantity)
        {
            var update = Builders<InventoryItem>.Update.Set(i => i.Quantity, newQuantity);
            _context.Inventory.UpdateOne(i => i.InventoryId == inventoryId, update);
        }

        public void ViewInventory()
        {
            var inventoryItems = _context.Inventory.Find(i => true).ToList();
            foreach (var item in inventoryItems)
            {
                var product = _context.Products.Find(p => p.ProductId == item.ProductId).FirstOrDefault();
                if (product != null)
                {
                    Console.WriteLine($"InventoryId: {item.InventoryId}, ProductName: {product.Name}, Quantity: {item.Quantity}");
                }
            }
        }

        public void DeleteInventoryItem(string inventoryId)
        {
            _context.Inventory.DeleteOne(i => i.InventoryId == inventoryId);
        }
    }
}
