using System.Threading.Tasks;

namespace Domain.Services.FitnessPackage
{
    public interface IFitnessPackageClient
    {
        Task<FitnessModel> GetFitnessPackage(string fitnessName, string token);
    }
}