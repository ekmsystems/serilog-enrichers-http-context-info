using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class HttpMethodEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public HttpMethodEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal HttpMethodEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("HttpMethod", new ScalarValue(httpContext.Request.HttpMethod))
                .AddIfAbsent(logEvent);
        }
    }
}