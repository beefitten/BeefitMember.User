using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
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
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromMilliseconds(500),
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2)
                });
            
            try
            {
                var model = new FitnessModel();
                
                await retryPolicy.ExecuteAsync(async () =>
                {
                    var response = await _client.GetAsync($"https://beefitmemberfitnesspackage.azurewebsites.net/getFitnessPackage/{fitnessName}");
                    var content = await response.Content.ReadAsStringAsync();
                    FitnessPackageReturnModel json = JsonConvert.DeserializeObject<FitnessPackageReturnModel>(content);

                    model.Token = token;
                    model.Name = json.Name;
                    model.Logo = json.Logo;
                    model.Features = json.Features;
                    model.PrimaryColor = json.PrimaryColor;
                    model.SecondaryColor = json.SecondaryColor;
                    model.ThirdColor = json.ThirdColor;
                    model.BackgroundColor = json.BackgroundColor;
                    model.BorderRadius = json.BorderRadius;
                    model.Elevation = json.Elevation;
                    model.OverView = json.OverView;
                    model.WeightGoal = json.WeightGoal;
                    model.CenterInformation = json.CenterInformation;
                    model.More = json.More;
                    model.Font = json.Font;
                    model.Bookings = json.Bookings;
                });
                
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}