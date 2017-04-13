using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class RequestTypeEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public RequestTypeEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal RequestTypeEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("RequestType", new ScalarValue(httpContext.Request.RequestType))
                .AddIfAbsent(logEvent);
        }
    }
}