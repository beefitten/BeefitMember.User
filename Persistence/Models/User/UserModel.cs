using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Persistence.Models.User
{
    public class UserModel
    {
        [BsonId]
        [BsonRequired]
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        [BsonRequired]
        public string Password { get; set; }
        
        [BsonElement("Subscription")]
        public string Subscription { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }
        
        [BsonElement("Last Name")]
        public string LastName { get; set; }

        [BsonElement("Primary Gym")]
        public string PrimaryGym { get; set; }
        
        [BsonElement("Secondary Gyms")]
        public List<String> SecondaryGyms { get; set; }
        
        [BsonElement("Role")]
        public string Role { get; set; }
        
        [BsonElement("Card number")]
        public string CardNumber { get; set; }
        
        [BsonElement("Expire year")]
        public string ExpireYear { get; set; }
        
        [BsonElement("Expire month")]
        public string ExpireMonth { get; set; }
        
        [BsonElement("CSC")]
        public int CSC { get; set; }
        
        [BsonElement("Cardholder name")]
        public string CardholderName { get; set; }
        
        [BsonElement("Issuer")]
        public string Issuer { get; set; }
    }
}