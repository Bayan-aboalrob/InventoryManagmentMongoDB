namespace InventoryManagmentMongoDB
{
    public class Inventory
    {
        private Database database;

        public Inventory(string connectionString, string databaseName)
        {
            database = new Database(connectionString, databaseName);
        }

        public void AddOrUpdateInventoryItem(string productName, int quantity)
        {
            database.AddOrUpdateInventoryItem(productName, quantity);
        }

        public void ViewInventory()
        {
            database.ViewInventory();
        }

        public void EditInventoryItem(string inventoryId, int newQuantity)
        {
            database.EditInventoryItem(inventoryId, newQuantity);
        }

        public void DeleteInventoryItem(string inventoryId)
        {
            database.DeleteInventoryItem(inventoryId);
        }
    }
}
