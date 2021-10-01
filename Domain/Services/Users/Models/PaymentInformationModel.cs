namespace Domain.Services.Users.Models
{
    public class PaymentInformationModel
    {
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public int CSC { get; set; }
        public string CardholderName { get; set; }
        public string Issuer { get; set; }
    }
}