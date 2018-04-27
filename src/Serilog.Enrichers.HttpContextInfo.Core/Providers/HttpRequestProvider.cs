using Microsoft.AspNetCore.Http;
using System.Web;

namespace Serilog.Providers
{
    public interface IHttpRequestProvider
    {
        IHttpRequestWrapper GetRequest();
    }

    public class HttpRequestProvider : IHttpRequestProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpRequestProvider() : this(new HttpContextAccessor()) { }

        public HttpRequestProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IHttpRequestWrapper GetRequest()
        {
            return _httpContextAccessor.HttpContext== null
                ? null
                : new HttpRequestWrapper(_httpContextAccessor.HttpContext.Request);
        }
    }
}