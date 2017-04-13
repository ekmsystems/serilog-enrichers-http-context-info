using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class RawUrlEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public RawUrlEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal RawUrlEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("RawUrl", new ScalarValue(httpContext.Request.RawUrl))
                .AddIfAbsent(logEvent);
        }
    }
}