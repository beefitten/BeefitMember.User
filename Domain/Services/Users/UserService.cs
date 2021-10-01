using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Users.Models;
using Domain.Setup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Models.User;
using Persistence.Repositories.User;

namespace Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        // Todo: Hide all this secrets
        private const string SECRET_KEY = "TQvgjeABMPOwCycOqah5EQu5yyVjpmVG";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
        
        public UserService()
        {
            var fixture = new TextFixtureData();
            _userRepository = fixture.ServiceProvider.GetService<IUserRepository>();
        }
        
        public async Task<bool> Register(RegisterModel model)
        {
            var userModel = new UserModel
            {
                Email = model.Email,
                Password = model.Password,
                Subscription = model.Subscription,
                Name = model.Name,
                LastName = model.LastName,
                PrimaryGym = model.PrimaryGym,
                SecondaryGyms = model.SecondaryGyms,
                Role = model.Role.ToString(),
                CardNumber = model.PaymentInfo.CardNumber,
                ExpireYear = model.PaymentInfo.ExpireYear,
                ExpireMonth = model.PaymentInfo.ExpireMonth,
                CSC = model.PaymentInfo.CSC,
                CardholderName = model.PaymentInfo.CardholderName,
                Issuer = model.PaymentInfo.Issuer
            };
            
            userModel.Password = EncryptPassword(model.Password);

            return await _userRepository.Register(userModel);
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var account = await _userRepository.FindUser(email) ?? throw new Exception("User not  found");

            var authenticateResult = BCrypt.Net.BCrypt.Verify(password, account.Password);
            
            if (authenticateResult)
                return GenerateToken(email);

            return "false";
        }

        private string EncryptPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        private string GenerateToken(string username)
        {
            var token = new JwtSecurityToken(
                claims:    new Claim[] { new Claim(ClaimTypes.Name, username) },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires:   new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY,
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}