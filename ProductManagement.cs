namespace InventoryManagmentMongoDB
{
    public class ProductManagement
    {
        private Database database;

        public ProductManagement(string connectionString, string databaseName)
        {
            database = new Database(connectionString, databaseName);
        }

        public void AddProduct(Product product)
        {
            database.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return database.GetAllProducts();
        }

        public Product FindProductByName(string name)
        {
            return database.FindProductByName(name);
        }

        public Product FindProductById(string productId)
        {
            return database.FindProductById(productId);
        }

        public void DeleteProduct(string productId)
        {
            database.DeleteProduct(productId);
        }
    }
}
