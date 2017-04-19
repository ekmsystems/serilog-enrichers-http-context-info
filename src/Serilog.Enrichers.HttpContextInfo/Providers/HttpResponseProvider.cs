using System.Web;

namespace Serilog.Providers
{
    public interface IHttpResponseProvider
    {
        IHttpResponseWrapper GetResponse();
    }

    internal class HttpResponseProvider : IHttpResponseProvider
    {
        public IHttpResponseWrapper GetResponse()
        {
            return HttpContext.Current == null
                ? null
                : new HttpResponseWrapper(HttpContext.Current.Response);
        }
    }
}
