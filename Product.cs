using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace InventoryManagmentMongoDB
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void DisplayProduct()
        {
            Console.WriteLine($"ProductId: {ProductId}, Name: {Name}, Price: {Price:C}");
        }
    }

}
