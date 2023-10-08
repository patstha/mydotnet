using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace hellolib;

public class Weather
{
    private readonly HttpClient _httpClient;

    public Weather(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CurrentWeather> GetCurrentWeatherAsync(string latitude, string longitude)
    {
        var url = $"https://api.weather.gov/points/{latitude},{longitude}/forecast/current";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var currentWeather = JsonSerializer.Deserialize<CurrentWeather>(content);

            return currentWeather;
        }
        else
        {
            throw new Exception($"Failed to get weather information: {response.StatusCode}");
        }
    }
}

public class CurrentWeather
{
    public string Temperature { get; set; }
    public string Humidity { get; set; }
    public string WindSpeed { get; set; }
    public string WindDirection { get; set; }
}