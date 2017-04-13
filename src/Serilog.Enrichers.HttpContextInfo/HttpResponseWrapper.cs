using System.IO;
using System.Web;

namespace Serilog
{
    public interface IHttpResponseWrapper
    {
        TextWriter Output { get; }
    }

    internal class HttpResponseWrapper : IHttpResponseWrapper
    {
        private readonly HttpResponse _httpResponse;

        public HttpResponseWrapper(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public TextWriter Output => _httpResponse.Output;
    }
}