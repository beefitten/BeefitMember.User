using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Domain.Services.FitnessPackage
{
    public class FitnessPackageClient : IFitnessPackageClient
    {
        public async Task<FitnessModel> GetFitnessPackage(string fitnessName, string token)
        {
            var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            try
            {
                var response = await client.GetAsync($"https://beefitmemberfitnesspackage.azurewebsites.net/getFitnessPackage/{fitnessName}");
                var content = await response.Content.ReadAsStringAsync();
                FitnessPackageReturnModel json = JsonConvert.DeserializeObject<FitnessPackageReturnModel>(content);
                
                var model = new FitnessModel()
                {
                    Token = token,
                    Name = json.Name,
                    Logo = json.Logo,
                    Features = json.Features,
                    PrimaryColor = json.PrimaryColor,
                    SecondaryColor = json.SecondaryColor
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