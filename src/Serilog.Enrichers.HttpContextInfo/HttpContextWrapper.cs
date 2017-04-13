using System.Web;

namespace Serilog
{
    public interface IHttpContextWrapper
    {
        IHttpRequestWrapper Request { get; }
        IHttpResponseWrapper Response { get; }
    }

    internal class HttpContextWrapper : IHttpContextWrapper
    {
        private readonly HttpContext _httpContext;

        public HttpContextWrapper(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public IHttpRequestWrapper Request => new HttpRequestWrapper(_httpContext.Request);
        public IHttpResponseWrapper Response => new HttpResponseWrapper(_httpContext.Response);
    }
}