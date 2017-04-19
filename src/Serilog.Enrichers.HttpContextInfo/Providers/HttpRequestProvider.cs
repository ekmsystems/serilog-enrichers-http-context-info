using System.Web;

namespace Serilog.Providers
{
    public interface IHttpRequestProvider
    {
        IHttpRequestWrapper GetRequest();
    }

    internal class HttpRequestProvider : IHttpRequestProvider
    {
        public IHttpRequestWrapper GetRequest()
        {
            return HttpContext.Current == null
                ? null
                : new HttpRequestWrapper(HttpContext.Current.Request);
        }
    }
}