using System.Net;
using System.Threading;

namespace tests;
public class MyCleanerTestsMocked
{
    private readonly ILogger<MyCleaner> _logger;
    private readonly HttpClient _httpClient;
    private readonly MyCleaner _myCleaner;
    private readonly TestHttpMessageHandler _httpMessageHandler;

    public MyCleanerTestsMocked()
    {
        _logger = Substitute.For<ILogger<MyCleaner>>();
        _httpMessageHandler = new TestHttpMessageHandler();
        _httpClient = new HttpClient(_httpMessageHandler);
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
        _httpMessageHandler.SendAsyncFunc = (request, cancellationToken) =>
        {
            if (request.RequestUri == new Uri(url))
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri(redirectedUrl) }
                });
            }
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = new HttpRequestMessage(HttpMethod.Get, redirectedUrl)
            });
        };

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
        _httpMessageHandler.SendAsyncFunc = (request, cancellationToken) =>
            Task.FromException<HttpResponseMessage>(new Exception("Network error"));

        // Act
        var result = await _myCleaner.CleanUrlAsync(url);

        // Assert
        result.Should().BeNull();
        _logger.Received(1).LogError(Arg.Any<Exception>(), "Error processing URL: {Url}", url);
    }
}


public class TestHttpMessageHandler : HttpMessageHandler
{
    public Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> SendAsyncFunc { get; set; }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return SendAsyncFunc(request, cancellationToken);
    }
}