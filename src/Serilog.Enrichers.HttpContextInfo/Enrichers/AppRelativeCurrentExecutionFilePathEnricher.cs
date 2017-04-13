using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class AppRelativeCurrentExecutionFilePathEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public AppRelativeCurrentExecutionFilePathEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal AppRelativeCurrentExecutionFilePathEnricher(IHttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            var httpContext = _httpContextProvider.GetCurrentContext();

            if (httpContext == null)
                return;

            propertyFactory
                .CreateProperty("AppRelativeCurrentExecutionFilePath", new ScalarValue(httpContext.Request.AppRelativeCurrentExecutionFilePath))
                .AddIfAbsent(logEvent);
        }
    }
}
