using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InventoryManagmentMongoDB
{
    public class InventoryItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InventoryId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(string productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public void DisplayInventoryItem()
        {
            Console.WriteLine($"InventoryId: {InventoryId}, ProductId: {ProductId}, Quantity: {Quantity}");
        }
    }
}
