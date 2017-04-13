using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class TotalBytesEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public TotalBytesEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal TotalBytesEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("TotalBytes", new ScalarValue(httpContext.Request.TotalBytes))
                .AddIfAbsent(logEvent);
        }
    }
}