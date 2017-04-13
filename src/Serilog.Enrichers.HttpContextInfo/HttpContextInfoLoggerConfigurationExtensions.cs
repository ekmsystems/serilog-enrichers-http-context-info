using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    public static class HttpContextInfoLoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithRequest(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new RequestEnricher());
        }
    }
}