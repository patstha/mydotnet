using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace tests
{
    public class MyCleanerTestsMocked
    {
        private readonly ILogger<MyCleaner> _logger;
        private readonly MyCleaner _myCleaner;
        private readonly TestHttpMessageHandler _httpMessageHandler;

        public MyCleanerTestsMocked()
        {
            _logger = Substitute.For<ILogger<MyCleaner>>();
            _httpMessageHandler = new TestHttpMessageHandler();
            HttpClient httpClient = new(_httpMessageHandler);
            _myCleaner = new MyCleaner(_logger, httpClient);
        }

        [Fact]
        public async Task CleanUrlAsync_ShouldReturnEmptyString_WhenUrlIsNullOrWhiteSpace()
        {
            // Arrange
            string url = "";

            // Act
            string result = await _myCleaner.CleanUrlAsync(url);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task CleanUrlAsync_ShouldReturnExtractedUrl_WhenUrlContainsQueryParameter()
        {
            // Arrange
            const string url = "https://example.com?u=https://redirected.com/";
            const string expectedUrl = "https://redirected.com/";

            // Act
            string result = await _myCleaner.CleanUrlAsync(url);

            // Assert
            result.Should().Be(expectedUrl);
        }

        [Fact]
        public async Task CleanUrlAsync_ShouldReturnFinalRedirectUrl_WhenUrlIsRedirected()
        {
            // Arrange
            const string url = "https://example.com/";
            const string redirectedUrl = "https://redirected.com/";
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
            string result = await _myCleaner.CleanUrlAsync(url);

            // Assert
            result.Should().Be(redirectedUrl);
        }

        [Fact]
        public async Task CleanUrlAsync_ShouldLogError_WhenExceptionIsThrown()
        {
            // Arrange
            const string url = "https://example.com";
            _httpMessageHandler.SendAsyncFunc = (request, cancellationToken) =>
                Task.FromException<HttpResponseMessage>(new Exception("Network error"));

            // Act
            string result = await _myCleaner.CleanUrlAsync(url);

            // Assert
            result.Should().BeNull();
            _logger.Received(1).LogError(
                Arg.Is<Exception>(ex => ex.Message == "Network error"),
                "Error processing URL: {Url}",
                url
            );
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
}