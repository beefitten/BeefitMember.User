using System;
using System.Net.Http;
using System.Threading.Tasks;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Domain.Services.FitnessPackage
{
    public class FitnessPackageClient : IFitnessPackageClient
    {
        private readonly HttpClient _client;
        public FitnessPackageClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<FitnessModel> GetFitnessPackage(string fitnessName, string token)
        {
            // var httpClientHandler = new HttpClientHandler
            // {
            //     AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            // };
            //
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            try
            {
                var response = await _client.GetAsync($"https://beefitmemberfitnesspackage.azurewebsites.net/getFitnessPackage/{fitnessName}");
                var content = await response.Content.ReadAsStringAsync();
                FitnessPackageReturnModel json = JsonConvert.DeserializeObject<FitnessPackageReturnModel>(content);
                
                var model = new FitnessModel()
                {
                    Token = token,
                    Name = json.Name,
                    Logo = json.Logo,
                    Features = json.Features,
                    PrimaryColor = json.PrimaryColor,
                    SecondaryColor = json.SecondaryColor,
                    ThirdColor = json.ThirdColor,
                    BackgroundColor = json.BackgroundColor,
                    BorderRadius = json.BorderRadius,
                    Elevation = json.Elevation,
                    OverView = json.OverView,
                    WeightGoal = json.WeightGoal,
                    CenterInformation = json.CenterInformation,
                    More = json.More,
                    Font = json.Font,
                    Bookings = json.Bookings
                };

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}