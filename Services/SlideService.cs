using SlideGeneratorAPI.Interfaces;
using SlideGeneratorAPI.Models;
using static System.Net.WebRequestMethods;

namespace SlideGeneratorAPI.Services
{
    public class SlideService : ISlideService
    {
        private readonly HttpClient _httpClient;
        private readonly string _scriptUrl;

        public SlideService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _scriptUrl = configuration["GoogleAppsScriptUrl"] ?? throw new ArgumentNullException("Url was not found in configuration");
        }
        public async Task<string> GenerateSlidesAsync(SlideRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(_scriptUrl, request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            return result?["url"] ?? "No URL was returned";
        }
    }
}
