using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persistence.Models.User
{
    public class UserModel
    {
        [BsonId]
        public string Id { get; set; }
        
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }
        
        [BsonElement("Surname")]
        public string Surname { get; set; }
        
        [BsonElement("Fitness")]
        public string Fitness { get; set; }
    }
}