using System.IO;
using System.Web;

namespace Serilog.Wrappers
{
    internal class WrappedHttpResponse : IHttpResponseWrapper
    {
        private readonly HttpResponse _httpResponse;

        public WrappedHttpResponse(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public TextWriter Output => _httpResponse.Output;
    }
}