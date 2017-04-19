using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace Serilog
{
    public interface IHttpResponseWrapper
    {
        NameValueCollection Headers { get; }
        TextWriter Output { get; }
        string Status { get; }
        int StatusCode { get; }
    }

    internal class HttpResponseWrapper : IHttpResponseWrapper
    {
        private readonly HttpResponse _httpResponse;

        public HttpResponseWrapper(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public NameValueCollection Headers => _httpResponse.Headers;
        public TextWriter Output => _httpResponse.Output;
        public string Status => _httpResponse.Status;
        public int StatusCode => _httpResponse.StatusCode;
    }
}