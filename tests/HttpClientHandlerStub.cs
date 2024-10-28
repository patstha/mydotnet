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
//
// public class HttpClientHandlerStub : HttpMessageHandler
// {
//     private readonly Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> _sendAsync;
//
//     public HttpClientHandlerStub(Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> sendAsync)
//     {
//         _sendAsync = sendAsync;
//     }
//
//     protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//     {
//         return Task.FromResult(_sendAsync(request, cancellationToken));
//     }
// }