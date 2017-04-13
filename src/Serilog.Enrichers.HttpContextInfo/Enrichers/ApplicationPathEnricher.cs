using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class ApplicationPathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public ApplicationPathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal ApplicationPathEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("ApplicationPath", new ScalarValue(httpContext.Request.ApplicationPath))
                .AddIfAbsent(logEvent);
        }
    }
}