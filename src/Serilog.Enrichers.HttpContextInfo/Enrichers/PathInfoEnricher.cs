using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class PathInfoEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public PathInfoEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal PathInfoEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("PathInfo", new ScalarValue(httpContext.Request.PathInfo))
                .AddIfAbsent(logEvent);
        }
    }
}