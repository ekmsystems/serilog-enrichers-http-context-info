using System.Collections.Generic;
using Serilog.Events;

namespace Serilog.Converters
{
    public interface ILogEventPropertyConverter<in T>
    {
        IEnumerable<LogEventProperty> Convert(T obj);
    }
}
