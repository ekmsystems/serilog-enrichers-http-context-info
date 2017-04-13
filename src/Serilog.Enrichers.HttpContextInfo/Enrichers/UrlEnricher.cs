using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class UrlEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public UrlEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal UrlEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("Url", new ScalarValue(httpContext.Request.Url.ToString()))
                .AddIfAbsent(logEvent);
        }
    }
}