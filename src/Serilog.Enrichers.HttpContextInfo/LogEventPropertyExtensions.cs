using Serilog.Events;

namespace Serilog
{
    internal static class LogEventPropertyExtensions
    {
        public static void AddIfAbsent(this LogEventProperty property, LogEvent logEvent)
        {
            logEvent.AddPropertyIfAbsent(property);
        }
    }
}