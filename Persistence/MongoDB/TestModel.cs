using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persistence.MongoDB
{
    public class TestModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Sex { get; set; }
    }
}