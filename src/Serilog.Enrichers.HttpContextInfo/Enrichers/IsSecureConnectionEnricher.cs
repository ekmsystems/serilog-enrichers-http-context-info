using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class IsSecureConnectionEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public IsSecureConnectionEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal IsSecureConnectionEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("IsSecureConnection", new ScalarValue(httpContext.Request.IsSecureConnection))
                .AddIfAbsent(logEvent);
        }
    }
}