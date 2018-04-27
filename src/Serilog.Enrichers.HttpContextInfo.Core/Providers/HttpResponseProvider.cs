using Microsoft.AspNetCore.Http;
using System.Web;

namespace Serilog.Providers
{
    public interface IHttpResponseProvider
    {
        IHttpResponseWrapper GetResponse();
    }

    public class HttpResponseProvider : IHttpResponseProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpResponseProvider() : this(new HttpContextAccessor()) { }

        public HttpResponseProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IHttpResponseWrapper GetResponse()
        {
            return _httpContextAccessor.HttpContext == null
                ? null
                : new HttpResponseWrapper(_httpContextAccessor.HttpContext.Response);
        }
    }
}
