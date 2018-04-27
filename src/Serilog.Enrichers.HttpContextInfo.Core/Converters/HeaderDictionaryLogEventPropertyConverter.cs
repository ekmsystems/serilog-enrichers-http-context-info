using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;

namespace Serilog.Converters
{
    public class HeaderDictionaryLogEventPropertyConverter : ILogEventPropertyConverter<IHeaderDictionary>
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _propertyName;

        public HeaderDictionaryLogEventPropertyConverter(
            ILogEventPropertyFactory propertyFactory,
            string propertyName)
        {
            _propertyFactory = propertyFactory;
            _propertyName = propertyName;
        }

        public IEnumerable<LogEventProperty> Convert(IHeaderDictionary obj)
        {
            return obj?.Keys.Select(key => CreateProperty(key, obj[key]))
                   ?? Enumerable.Empty<LogEventProperty>();
        }

        private LogEventProperty CreateProperty(string key, string value)
        {
            return _propertyFactory.CreateProperty($"{_propertyName}[{key}]", value);
        }
    }
}
