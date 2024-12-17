using System.Net;

namespace tests;

public class MyCleanerTestsMocked
{
    private readonly ILogger<MyCleaner> _logger;
    private readonly HttpClient _httpClient;
    private readonly MyCleaner _myCleaner;

    public MyCleanerTestsMocked()
    {
        _logger = Substitute.For<ILogger<MyCleaner>>();
        _httpClient = Substitute.For<HttpClient>();
        _myCleaner = new MyCleaner(_logger, _httpClient);
    }

    [Fact]
    public async Task CleanUrlAsync_ShouldReturnEmptyString_WhenUrlIsNullOrWhiteSpace()
    {
        // Arrange
        string url = "";

        // Act
        var result = await _myCleaner.CleanUrlAsync(url);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task CleanUrlAsync_ShouldReturnExtractedUrl_WhenUrlContainsQueryParameter()
    {
        // Arrange
        string url = "http://example.com?u=http://redirected.com";
        string expectedUrl = "http://redirected.com";

        // Act
        var result = await _myCleaner.CleanUrlAsync(url);

        // Assert
        result.Should().Be(expectedUrl);
    }

    [Fact]
    public async Task CleanUrlAsync_ShouldReturnFinalRedirectUrl_WhenUrlIsRedirected()
    {
        // Arrange
        string url = "http://example.com";
        string redirectedUrl = "http://redirected.com";
        var response = new HttpResponseMessage(HttpStatusCode.Redirect)
        {
            Headers = { Location = new Uri(redirectedUrl) }
        };
        _httpClient.GetAsync(url).Returns(Task.FromResult(response));
        _httpClient.GetAsync(redirectedUrl).Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
            RequestMessage = new HttpRequestMessage(HttpMethod.Get, redirectedUrl)
        }));

        // Act
        var result = await _myCleaner.CleanUrlAsync(url);

        // Assert
        result.Should().Be(redirectedUrl);
    }

    [Fact]
    public async Task CleanUrlAsync_ShouldLogError_WhenExceptionIsThrown()
    {
        // Arrange
        string url = "http://example.com";
        _httpClient.GetAsync(url).Returns(Task.FromException<HttpResponseMessage>(new Exception("Network error")));

        // Act
        var result = await _myCleaner.CleanUrlAsync(url);

        // Assert
        result.Should().BeNull();
        _logger.Received(1).LogError(Arg.Any<Exception>(), "Error processing URL: {Url}", url);
    }
}