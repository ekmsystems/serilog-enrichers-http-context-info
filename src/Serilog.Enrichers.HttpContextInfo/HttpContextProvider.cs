using System.Web;
using Serilog.Wrappers;

namespace Serilog
{
    public interface IHttpContextProvider
    {
        IHttpContextWrapper GetCurrentContext();
    }

    internal class HttpContextProvider : IHttpContextProvider
    {
        public IHttpContextWrapper GetCurrentContext()
        {
            return HttpContext.Current == null
                ? null
                : new WrappedHttpContext(HttpContext.Current);
        }
    }
}