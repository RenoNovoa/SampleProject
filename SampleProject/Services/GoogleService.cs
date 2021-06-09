using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SampleProject.Services
{
    public class GoogleService : IGoogleService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string GooglePlacesApiKey => _configuration["GooglePlacesApiKey"];
        private string GoogleFitnesssApiKey => _configuration["GoogleFitnessApiKey"];

        public GoogleService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<object> GetPlacesAsync(string zipCode)
        {
            var endpoint = $"geocode/something";
            var queryParameters = $"?area={zipCode}&key={GooglePlacesApiKey}";

            var url = _httpClient.BaseAddress + endpoint + queryParameters;

            var results = await _httpClient.GetFromJsonAsync<object>(url);

            return results;
        }

        public async Task<object> GetFitnessAsync(string latitude, string longitude)
        {
            var endpoint = $"geocode/something";
            var queryParameters = $"?location={latitude},{longitude}&key={GoogleFitnesssApiKey}";

            var url = _httpClient.BaseAddress + endpoint + queryParameters;

            var results = await _httpClient.GetFromJsonAsync<object>(url);

            return results;
        }
    }
}
