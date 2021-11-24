namespace Domain.Services.Security
{
    public interface ISecurity
    {
        public string HashAndSaltPassword(string password);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}