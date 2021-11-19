using System;
using System.Collections.Generic;

namespace Persistence.Models.User
{
    public class UserReturnModel
    {
        public string StatusCode { get; set; }
        
        public string Email { get; set; }
        public string Subscription { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string PrimaryGym { get; set; }
        public List<String> SecondaryGyms { get; set; }
        public string Role { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public int CSC { get; set; }
        public string CardholderName { get; set; }
        public string Issuer { get; set; }
        public string Token { get; set; }
    }
}