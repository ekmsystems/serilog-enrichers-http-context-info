using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class UrlReferrerEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public UrlReferrerEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal UrlReferrerEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("UrlReferrer", new ScalarValue(httpContext.Request.UrlReferrer.ToString()))
                .AddIfAbsent(logEvent);
        }
    }
}