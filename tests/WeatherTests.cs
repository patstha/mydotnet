﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;
using hellolib;
using NSubstitute.ExceptionExtensions;
using System.Threading;
using System.Text.Json;

namespace tests;
public class WeatherTests
{
    [Fact]
    public async Task GetCurrentWeatherAsync_ReturnsCurrentWeather_WhenRequestIsSuccessful()
    {
        // Arrange
        var expectedWeather = new CurrentWeather
        {
            Temperature = "20",
            Humidity = "30",
            WindSpeed = "10",
            WindDirection = "North"
        };

        var messageHandler = new HttpMessageHandlerStub(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(expectedWeather))
        });

        var httpClient = new HttpClient(messageHandler);
        var weatherService = new Weather(httpClient);

        // Act
        var result = await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        result.Should().BeEquivalentTo(expectedWeather);
    }

    [Fact]
    public void GetCurrentWeatherAsync_ThrowsException_WhenRequestIsUnsuccessful()
    {
        // Arrange
        var messageHandler = new HttpMessageHandlerStub(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.NotFound
        });

        var httpClient = new HttpClient(messageHandler);
        var weatherService = new Weather(httpClient);

        // Act
        Func<Task> act = async () => await weatherService.GetCurrentWeatherAsync("37.7833", "-122.4167");

        // Assert
        act.Should().ThrowAsync<Exception>().WithMessage("Failed to get weather information: NotFound");
    }
}

public class HttpMessageHandlerStub : HttpMessageHandler
{
    private readonly HttpResponseMessage _response;

    public HttpMessageHandlerStub(HttpResponseMessage response)
    {
        _response = response;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_response);
    }
}