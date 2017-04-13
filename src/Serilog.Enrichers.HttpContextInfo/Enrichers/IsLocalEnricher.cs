using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class IsLocalEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public IsLocalEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal IsLocalEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("IsLocal", new ScalarValue(httpContext.Request.IsLocal))
                .AddIfAbsent(logEvent);
        }
    }
}