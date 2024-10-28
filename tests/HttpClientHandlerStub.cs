using System.Threading;

namespace tests;

public class HttpClientHandlerStub(Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> sendAsync)
    : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(sendAsync(request, cancellationToken));
    }
}
