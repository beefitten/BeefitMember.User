using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persistence.Models.Test
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