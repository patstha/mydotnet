using System.Net;
using System.Threading;
using System.Text.Json;

namespace tests;
public class WeatherTests
{
    [Fact]
    public async Task GetCurrentWeatherAsync_ReturnsCurrentWeather_WhenRequestIsSuccessful()
    {
        // Arrange
        CurrentWeather expectedWeather = new()
        {
            Temperature = "20",
            Humidity = "30",
            WindSpeed = "10",
            WindDirection = "North"
        };

        HttpMessageHandlerStub messageHandler = new(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(expectedWeather))
        });

        HttpClient httpClient = new(messageHandler);
        Weather weatherService = new(httpClient);

        // Act
        CurrentWeather result = await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        result.Should().BeEquivalentTo(expectedWeather);
    }

    [Fact]
    public void GetCurrentWeatherAsync_ThrowsException_WhenRequestIsUnsuccessful()
    {
        // Arrange
        HttpMessageHandlerStub messageHandler = new(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.NotFound
        });

        HttpClient httpClient = new(messageHandler);
        Weather weatherService = new(httpClient);

        // Act
        Func<Task> act = async () => await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        act.Should().ThrowAsync<Exception>().WithMessage("Failed to get weather information: NotFound");
    }
    [Fact]
    public async Task GetCurrentWeatherAsync_ReturnsCurrentWeather_WhenRequestIsSuccessfulAndDataIsPartial()
    {
        // Arrange
        CurrentWeather expectedWeather = new()
        {
            Temperature = "20",
            Humidity = null,
            WindSpeed = null,
            WindDirection = null
        };

        HttpMessageHandlerStub messageHandler = new(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(expectedWeather))
        });

        HttpClient httpClient = new(messageHandler);
        Weather weatherService = new(httpClient);

        // Act
        CurrentWeather result = await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        result.Should().BeEquivalentTo(expectedWeather);
    }

    [Fact]
    public async Task GetCurrentWeatherAsync_ReturnsCurrentWeather_WhenRequestIsSuccessfulAndDataIsEmpty()
    {
        // Arrange
        CurrentWeather expectedWeather = new()
        {
            Temperature = null,
            Humidity = null,
            WindSpeed = null,
            WindDirection = null
        };

        HttpMessageHandlerStub messageHandler = new(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(expectedWeather))
        });

        HttpClient httpClient = new(messageHandler);
        Weather weatherService = new(httpClient);

        // Act
        CurrentWeather result = await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        result.Should().BeEquivalentTo(expectedWeather);
    }

    [Fact]
    public void GetCurrentWeatherAsync_ThrowsException_WhenRequestIsUnsuccessfulWithDifferentStatusCode()
    {
        // Arrange
        HttpMessageHandlerStub messageHandler = new(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.InternalServerError
        });

        HttpClient httpClient = new(messageHandler);
        Weather weatherService = new(httpClient);

        // Act
        Func<Task> act = async () => await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        act.Should().ThrowAsync<Exception>().WithMessage("Failed to get weather information: InternalServerError");
    }

}

public class HttpMessageHandlerStub(HttpResponseMessage response) : HttpMessageHandler
{
    private readonly HttpResponseMessage _response = response;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_response);
    }
}
