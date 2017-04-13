using System.Web;

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
            return new HttpContextWrapper(HttpContext.Current);
        }
    }
}
