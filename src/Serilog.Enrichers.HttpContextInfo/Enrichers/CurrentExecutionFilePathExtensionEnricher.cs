using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
    public class CurrentExecutionFilePathExtensionEnricher : ILogEventEnricher
    {
        private readonly IHttpContextProvider _httpContextProvider;

        public CurrentExecutionFilePathExtensionEnricher()
            : this(new HttpContextProvider())
        {
        }

        internal CurrentExecutionFilePathExtensionEnricher(IHttpContextProvider httpContextProvider)
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
                .CreateProperty("CurrentExecutionFilePathExtension",
                    new ScalarValue(httpContext.Request.CurrentExecutionFilePathExtension))
                .AddIfAbsent(logEvent);
        }
    }
}