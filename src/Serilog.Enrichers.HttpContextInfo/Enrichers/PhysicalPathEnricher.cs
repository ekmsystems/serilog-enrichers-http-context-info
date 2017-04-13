using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class PhysicalPathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public PhysicalPathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal PhysicalPathEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("PhysicalPath", new ScalarValue(httpContext.Request.PhysicalPath))
                .AddIfAbsent(logEvent);
        }
    }
}