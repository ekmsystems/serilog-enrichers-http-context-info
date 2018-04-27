using Microsoft.AspNetCore.Http;
using System.Web;

namespace Serilog.Providers
{
    public interface IHttpContextProvider
    {
        IHttpContextWrapper GetCurrentContext();
    }

    public class HttpContextProvider : IHttpContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextProvider() : this(new HttpContextAccessor()) { }

        public HttpContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IHttpContextWrapper GetCurrentContext()
        {
            return _httpContextAccessor.HttpContext == null
                ? null
                : new HttpContextWrapper(_httpContextAccessor.HttpContext);
        }
    }
}