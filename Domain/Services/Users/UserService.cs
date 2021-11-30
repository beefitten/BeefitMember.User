using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Security;
using Domain.Services.Users.Models;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Models.User;
using Persistence.Repositories.User;

namespace Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurity _security;

        private static readonly string SECRET_KEY = AppConfig.GetSecretKey();
        public static readonly SymmetricSecurityKey SIGNING_KEY = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            
        public UserService(IUserRepository userRepository, ISecurity security)
        {
            _userRepository = userRepository;
            _security = security;
        }
        
        public async Task<HttpStatusCode> Register(RegisterModel model)
        {
            var userModel = new UserModel
            {
                Email = model.Email,
                Password = model.Password,
                Subscription = model.Subscription,
                Name = model.Name,
                LastName = model.LastName,
                ProfileImage = model.ProfileImage,
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
            
            userModel.Password = _security.HashAndSaltPassword(model.Password);

            return await _userRepository.Register(userModel);
        }

        public async Task<UserReturnModel> Authenticate(string email, string password)
        {
            UserModel account = null; 
            
            try
            {
                account = await _userRepository.FindUser(email) ?? throw new Exception("User not found!");
            }
            catch (Exception e)
            {
                return new UserReturnModel
                {
                    StatusCode = UserServiceResults.Error.ToString()
                };
            }

            var authenticateResult = _security.VerifyPassword(password, account.Password);

            if (authenticateResult)
            {
                var token = GenerateToken(email, account.Role);
                
                return new UserReturnModel
                {
                    StatusCode = UserServiceResults.OK.ToString(),
                    Email = account.Email,
                    Subscription = account.Subscription,
                    Name = account.Name,
                    LastName = account.LastName,
                    ProfileImage = account.ProfileImage,
                    PrimaryGym = account.PrimaryGym,
                    SecondaryGyms = account.SecondaryGyms,
                    Role = account.Role,
                    CardNumber = account.CardNumber,
                    ExpireYear = account.ExpireYear,
                    ExpireMonth = account.ExpireMonth,
                    CSC = account.CSC,
                    CardholderName = account.CardholderName,
                    Issuer = account.Issuer,
                    Token = token
                };
            }
            return new UserReturnModel
            {
                StatusCode = UserServiceResults.IncorrectPassword.ToString()
            };
        }

        public async Task<UserReturnModel> FindUserInformation(string email)
        {
            return await _userRepository.FindUserInformation(email);
        }

        public async Task<HttpStatusCode> RemoveUser(string email)
        {
            return await _userRepository.RemoveUser(email);
        }

        private string GenerateToken(string username, string role)
        {
            var token = new JwtSecurityToken(
                claims:    new Claim[] { 
                    new Claim(ClaimTypes.Name, username), 
                    new Claim(ClaimTypes.Role, role),
                    new Claim("Role", role)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires:   new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY,
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}