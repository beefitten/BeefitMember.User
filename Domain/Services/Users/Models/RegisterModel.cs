using System;
using System.Collections.Generic;

namespace Domain.Services.Users.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Subscription { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string PrimaryGym { get; set; }
        public List<String> SecondaryGyms { get; set; }
        public Roles Role { get; set; }
        public PaymentInformationModel PaymentInfo { get; set; }
    }
}