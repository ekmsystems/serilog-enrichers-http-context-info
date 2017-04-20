using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Converters
{
    internal class NameValueCollectionLogEventPropertyConverter : ILogEventPropertyConverter<NameValueCollection>
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _propertyName;

        public NameValueCollectionLogEventPropertyConverter(
            ILogEventPropertyFactory propertyFactory,
            string propertyName)
        {
            _propertyFactory = propertyFactory;
            _propertyName = propertyName;
        }

        public IEnumerable<LogEventProperty> Convert(NameValueCollection obj)
        {
            return obj?.AllKeys.Select(key => CreateProperty(key, obj.Get(key)))
                   ?? Enumerable.Empty<LogEventProperty>();
        }

        private LogEventProperty CreateProperty(string key, string value)
        {
            return _propertyFactory.CreateProperty($"{_propertyName}[{key}]", value);
        }
    }
}
