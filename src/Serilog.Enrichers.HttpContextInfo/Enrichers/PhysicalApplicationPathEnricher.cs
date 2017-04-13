using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class PhysicalApplicationPathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public PhysicalApplicationPathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal PhysicalApplicationPathEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("PhysicalApplicationPath", new ScalarValue(httpContext.Request.PhysicalApplicationPath))
                .AddIfAbsent(logEvent);
        }
    }
}