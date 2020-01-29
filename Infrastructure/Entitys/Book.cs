using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Infrastructure.Entitys
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
