using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class PathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public PathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal PathEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("Path", new ScalarValue(httpContext.Request.Path))
                .AddIfAbsent(logEvent);
        }
    }
}