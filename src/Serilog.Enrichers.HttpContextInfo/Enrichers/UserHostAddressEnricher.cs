using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class UserHostAddressEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public UserHostAddressEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal UserHostAddressEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("UserHostAddress", new ScalarValue(httpContext.Request.UserHostAddress))
                .AddIfAbsent(logEvent);
        }
    }
}