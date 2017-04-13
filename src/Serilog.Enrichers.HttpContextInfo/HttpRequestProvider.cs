using System.Web;
using Serilog.Wrappers;

namespace Serilog
{
    public interface IHttpRequestProvider
    {
        IHttpRequestWrapper GetCurrentRequest();
    }

    internal class HttpRequestProvider : IHttpRequestProvider
    {
        public IHttpRequestWrapper GetCurrentRequest()
        {
            return HttpContext.Current == null
                ? null
                : new WrappedHttpRequest(HttpContext.Current.Request);
        }
    }
}
