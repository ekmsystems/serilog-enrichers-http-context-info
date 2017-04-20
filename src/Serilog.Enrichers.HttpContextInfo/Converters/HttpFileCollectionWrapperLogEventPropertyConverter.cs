using System.Collections.Generic;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Converters
{
    internal class HttpFileCollectionWrapperLogEventPropertyConverter : ILogEventPropertyConverter<IHttpFileCollectionWrapper>
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _propertyName;

        public HttpFileCollectionWrapperLogEventPropertyConverter(
            ILogEventPropertyFactory propertyFactory,
            string propertyName)
        {
            _propertyFactory = propertyFactory;
            _propertyName = propertyName;
        }

        public IEnumerable<LogEventProperty> Convert(IHttpFileCollectionWrapper obj)
        {
            return obj?.AllKeys.SelectMany(key => CreateProperty(key, obj.Get(key))) ??
                   Enumerable.Empty<LogEventProperty>();
        }

        private IEnumerable<LogEventProperty> CreateProperty(string key, IHttpPostedFileWrapper file)
        {
            yield return _propertyFactory.CreateProperty($"{_propertyName}[{key}].FileName", file.FileName);
            yield return _propertyFactory.CreateProperty($"{_propertyName}[{key}].ContentLength", file.ContentLength);
            yield return _propertyFactory.CreateProperty($"{_propertyName}[{key}].ContentType", file.ContentType);
        }
    }
}
