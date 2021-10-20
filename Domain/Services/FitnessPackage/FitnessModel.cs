using System.Collections.Generic;
using Persistence.Models.FitnessPackage;
using Persistence.Models.User;

namespace Domain.Services.FitnessPackage
{
    public class FitnessModel
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Logo { get; set; }
        public List<Features> Features { get; set; }
        public UserReturnModel UserInfo { get; set; }
    }
}