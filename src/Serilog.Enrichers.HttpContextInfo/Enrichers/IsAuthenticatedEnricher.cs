using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class IsAuthenticatedEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public IsAuthenticatedEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal IsAuthenticatedEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("IsAuthenticated", new ScalarValue(httpContext.Request.IsAuthenticated))
                .AddIfAbsent(logEvent);
        }
    }
}