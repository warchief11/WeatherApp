using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherApp.Tests
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public HttpRequestMessage RequestMessage { get; private set; }
        public HttpResponseMessage Respnose { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestMessage = request;          
            return Task.FromResult(Respnose);
        }
    }
}
