using System.Threading.Tasks;

namespace SampleProject.Services
{
    public interface IGoogleService
    {
        Task<object> GetPlacesAsync(string zipCode);
        Task<object> GetFitnessAsync(string latitude, string longitude);
    }
}