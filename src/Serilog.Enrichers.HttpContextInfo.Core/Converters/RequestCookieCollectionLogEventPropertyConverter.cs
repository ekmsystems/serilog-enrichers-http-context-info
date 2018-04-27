using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;

namespace Serilog.Converters
{
    public class RequestCookieCollectionLogEventPropertyConverter : ILogEventPropertyConverter<IRequestCookieCollection>
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _propertyName;

        public RequestCookieCollectionLogEventPropertyConverter(
            ILogEventPropertyFactory propertyFactory,
            string propertyName)
        {
            _propertyFactory = propertyFactory;
            _propertyName = propertyName;
        }

        public IEnumerable<LogEventProperty> Convert(IRequestCookieCollection obj)
        {
            return obj?.Keys.SelectMany(key => CreateProperties(key, obj[key]))
                   ?? Enumerable.Empty<LogEventProperty>();
        }

        private IEnumerable<LogEventProperty> CreateProperties(string key, string cookieValue)
        {
            yield return _propertyFactory
                .CreateProperty($"{_propertyName}[{key}]", cookieValue);
        }
    }
}
