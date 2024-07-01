namespace InventoryManagmentMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var databaseName = "InventoryManagementDB";
            var productManagement = new ProductManagement(connectionString, databaseName);
            var inventory = new Inventory(connectionString, databaseName);
            var CurrentlyRunning = true;

            while (CurrentlyRunning)
            {
                Console.WriteLine("\n Welcome to The Simple Inventory Management System \n ");
                Console.WriteLine("\n Please Choose One of The Following Options \n");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Add inventory item");
                Console.WriteLine("4. View inventory");
                Console.WriteLine("5. Edit inventory item");
                Console.WriteLine("6. Delete inventory item");
                Console.WriteLine("7. Search for a product");
                Console.WriteLine("8. Delete a product");
                Console.WriteLine("9. Exit");
                var UserOption = Console.ReadLine();

                switch (UserOption)
                {
                    case "1":
                        AddProduct(productManagement);
                        break;
                    case "2":
                        ViewProducts(productManagement);
                        break;
                    case "3":
                        AddInventoryItem(inventory);
                        break;
                    case "4":
                        ViewInventory(inventory);
                        break;
                    case "5":
                        EditInventoryItem(inventory);
                        break;
                    case "6":
                        DeleteInventoryItem(inventory);
                        break;
                    case "7":
                        SearchProduct(productManagement);
                        break;
                    case "8":
                        DeleteProduct(productManagement);
                        break;
                    case "9":
                        CurrentlyRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option!");
                        break;
                }
            }
        }

        static void AddProduct(ProductManagement productManagement)
        {
            Console.Write("Please enter product name: ");
            var name = Console.ReadLine();
            Console.Write("Please enter price: ");
            var price = decimal.Parse(Console.ReadLine());

            var product = new Product(name, price);
            try
            {
                productManagement.AddProduct(product);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewProducts(ProductManagement productManagement)
        {
            Console.WriteLine("\n Viewing Products......");
            var products = productManagement.GetAllProducts();
            foreach (var product in products)
            {
                product.DisplayProduct();
            }
        }

        static void AddInventoryItem(Inventory inventory)
        {
            Console.Write("Please enter product name: ");
            var name = Console.ReadLine();

            Console.Write("Please enter quantity: ");
            var quantity = int.Parse(Console.ReadLine());

            try
            {
                inventory.AddOrUpdateInventoryItem(name, quantity);
                Console.WriteLine("Inventory item added or updated successfully!");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewInventory(Inventory inventory)
        {
            Console.WriteLine("\n Viewing Inventory......");
            inventory.ViewInventory();
        }

        static void EditInventoryItem(Inventory inventory)
        {
            Console.Write("Please enter inventory ID to edit: ");
            var inventoryId = Console.ReadLine();

            Console.Write("Please enter new quantity: ");
            var newQuantity = int.Parse(Console.ReadLine());

            inventory.EditInventoryItem(inventoryId, newQuantity);

            Console.WriteLine("Inventory item updated successfully!");
        }

        static void DeleteInventoryItem(Inventory inventory)
        {
            Console.Write("Please enter inventory ID to delete: ");
            var inventoryId = Console.ReadLine();

            inventory.DeleteInventoryItem(inventoryId);

            Console.WriteLine("Inventory item deleted successfully!");
        }

        static void SearchProduct(ProductManagement productManagement)
        {
            Console.Write("Please enter product name to search: ");
            var name = Console.ReadLine();

            var product = productManagement.FindProductByName(name);
            if (product != null)
            {
                Console.WriteLine("Product found:");
                product.DisplayProduct();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void DeleteProduct(ProductManagement productManagement)
        {
            Console.Write("Please enter product ID to delete: ");
            var productId = Console.ReadLine();

            productManagement.DeleteProduct(productId);

            Console.WriteLine("Product deleted successfully!");
        }
    }
}