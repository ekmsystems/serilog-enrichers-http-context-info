using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    public static class HttpContextInfoLoggerConfigurationExtensions
    {
        public static LoggerConfiguration WithAnonymousId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<AnonymousIdEnricher>();
        }

        public static LoggerConfiguration WithApplicationPath(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ApplicationPathEnricher>();
        }

        public static LoggerConfiguration WithAppRelativeCurrentExecutionFilePath(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<AppRelativeCurrentExecutionFilePathEnricher>();
        }

        public static LoggerConfiguration WithContentEncoding(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ContentEncodingEnricher>();
        }

        public static LoggerConfiguration WithContentLength(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ContentLengthEnricher>();
        }

        public static LoggerConfiguration WithContentType(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ContentTypeEnricher>();
        }

        public static LoggerConfiguration WithCurrentExecutionFilePath(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<CurrentExecutionFilePathEnricher>();
        }

        public static LoggerConfiguration WithCurrentExecutionFilePathExtension(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<CurrentExecutionFilePathExtensionEnricher>();
        }

        public static LoggerConfiguration WithFilePath(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<FilePathEnricher>();
        }

        public static LoggerConfiguration WithUrl(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<UrlEnricher>();
        }

        public static LoggerConfiguration WithRawUrl(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<RawUrlEnricher>();
        }
    }
}
