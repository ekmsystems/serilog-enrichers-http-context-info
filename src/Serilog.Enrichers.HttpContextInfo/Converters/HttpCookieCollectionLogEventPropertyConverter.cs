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
            return obj?.AllKeys.SelectMany(key => CreateProperties(key, obj.Get(key)))
                   ?? Enumerable.Empty<LogEventProperty>();
        }

        private IEnumerable<LogEventProperty> CreateProperties(string key, HttpCookie httpCookie)
        {
            yield return _propertyFactory
                .CreateProperty($"{_propertyName}[{key}].Name", httpCookie.Name);
            yield return _propertyFactory
                .CreateProperty($"{_propertyName}[{key}].Value", httpCookie.Value);
            yield return _propertyFactory
                .CreateProperty($"{_propertyName}[{key}].Domain", httpCookie.Domain);
            yield return _propertyFactory
                .CreateProperty($"{_propertyName}[{key}].Expires", httpCookie.Expires.ToString("u"));
            yield return _propertyFactory
                .CreateProperty($"{_propertyName}[{key}].Path", httpCookie.Path);
        }
    }
}
