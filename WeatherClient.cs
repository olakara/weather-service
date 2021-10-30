using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;


namespace WeatherService
{
    public class WeatherClient
    {
       private readonly HttpClient _httpClient;
       private readonly ServiceSettings _serviceSettings;
        public WeatherClient(HttpClient httpClient, IOptions<ServiceSettings> options)
        {
            _httpClient = httpClient;
            _serviceSettings = options.Value;
        }

        public record Weather(string description);
        public record Main(decimal temp);
        public record Forcast(Weather[] weather, Main main, long dt);

        public async Task<Forcast> GetCurrentWeatherAsync(string city)
        {
            // var response = await _httpClient.GetAsync($"{_serviceSettings.BaseUrl}/{city}");
            // response.EnsureSuccessStatusCode();
            // var content = await response.Content.ReadAsStringAsync();
            // return JsonSerializer.Deserialize<Forcast>(content);

            var forecast = await _httpClient.GetFromJsonAsync<Forcast>($"https://{_serviceSettings.ServiceHost}/data/2.5/weather?q={city}&appid={_serviceSettings.ApiKey}&units=metric");
            return forecast;
        }

    }
}