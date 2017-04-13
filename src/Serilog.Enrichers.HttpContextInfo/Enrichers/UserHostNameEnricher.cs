using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class UserHostNameEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public UserHostNameEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal UserHostNameEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("UserHostName", new ScalarValue(httpContext.Request.UserHostName))
                .AddIfAbsent(logEvent);
        }
    }
}