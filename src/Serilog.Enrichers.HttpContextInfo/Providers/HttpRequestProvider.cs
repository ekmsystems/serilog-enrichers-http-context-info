using System.Web;

namespace Serilog.Providers
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
                : new HttpRequestWrapper(HttpContext.Current.Request);
        }
    }
}