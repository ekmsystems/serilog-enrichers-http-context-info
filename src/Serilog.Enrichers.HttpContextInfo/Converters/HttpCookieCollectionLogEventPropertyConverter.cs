using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Converters
{
    internal class HttpCookieCollectionLogEventPropertyConverter : ILogEventPropertyConverter<HttpCookieCollection>
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _propertyName;

        public HttpCookieCollectionLogEventPropertyConverter(
            ILogEventPropertyFactory propertyFactory,
            string propertyName)
        {
            _propertyFactory = propertyFactory;
            _propertyName = propertyName;
        }

        public IEnumerable<LogEventProperty> Convert(HttpCookieCollection obj)
        {
            return obj?.AllKeys
                       .SelectMany(key => new[]
                       {
                           _propertyFactory.CreateProperty(
                               $"{_propertyName}[{key}].Name",
                               obj[key].Name),
                           _propertyFactory.CreateProperty(
                               $"{_propertyName}[{key}].Value",
                               obj[key].Value),
                           _propertyFactory.CreateProperty(
                               $"{_propertyName}[{key}].Domain",
                               obj[key].Domain),
                           _propertyFactory.CreateProperty(
                               $"{_propertyName}[{key}].Expires",
                               obj[key].Expires.ToString("u")),
                           _propertyFactory.CreateProperty(
                               $"{_propertyName}[{key}].Path",
                               obj[key].Path)
                       })
                   ?? Enumerable.Empty<LogEventProperty>();
        }
    }
}
