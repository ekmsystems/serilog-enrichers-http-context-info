using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class UserAgentEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public UserAgentEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal UserAgentEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("UserAgent", new ScalarValue(httpContext.Request.UserAgent))
                .AddIfAbsent(logEvent);
        }
    }
}