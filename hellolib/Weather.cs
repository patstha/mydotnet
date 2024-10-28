using System.Text.Json;

namespace hellolib;

public class Weather(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<CurrentWeather> GetCurrentWeatherAsync(string latitude, string longitude)
    {
        string url = $"https://api.weather.gov/points/{latitude},{longitude}/forecast/current";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();

            CurrentWeather currentWeather = JsonSerializer.Deserialize<CurrentWeather>(content);

            return currentWeather;
        }

        throw new WeatherFetchException($"Failed to get weather information: {response.StatusCode}");
    }
}

public class CurrentWeather
{
    public string Temperature { get; set; }
    public string Humidity { get; set; }
    public string WindSpeed { get; set; }
    public string WindDirection { get; set; }
}

public class WeatherFetchException(string message) : Exception(message)
{
}
