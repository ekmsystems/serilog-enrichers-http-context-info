using System.Web;

namespace Serilog.Wrappers
{
    internal class WrappedHttpContext : IHttpContextWrapper
    {
        private readonly HttpContext _httpContext;

        public WrappedHttpContext(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public IHttpRequestWrapper Request => new WrappedHttpRequest(_httpContext.Request);
        public IHttpResponseWrapper Response => new WrappedHttpResponse(_httpContext.Response);
    }
}