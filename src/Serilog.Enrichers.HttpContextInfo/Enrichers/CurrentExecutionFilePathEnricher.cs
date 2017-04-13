using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class CurrentExecutionFilePathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public CurrentExecutionFilePathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal CurrentExecutionFilePathEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("CurrentExecutionFilePath",
                    new ScalarValue(httpContext.Request.CurrentExecutionFilePath))
                .AddIfAbsent(logEvent);
        }
    }
}