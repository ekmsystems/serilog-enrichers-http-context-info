using System.Collections.Generic;
using System.Linq;
using Serilog.Core;
using Serilog.Events;
using Microsoft.AspNetCore.Http;

namespace Serilog.Converters
{
    public class FormFileCollectionWrapperLogEventPropertyConverter : ILogEventPropertyConverter<IFormFileCollectionWrapper>
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _propertyName;

        public FormFileCollectionWrapperLogEventPropertyConverter(
            ILogEventPropertyFactory propertyFactory,
            string propertyName)
        {
            _propertyFactory = propertyFactory;
            _propertyName = propertyName;
        }

        public IEnumerable<LogEventProperty> Convert(IFormFileCollectionWrapper obj)
        {
            return obj?.AllKeys.SelectMany(k => CreateProperties(obj.Get(k))) ??
                   Enumerable.Empty<LogEventProperty>();
        }

        private IEnumerable<LogEventProperty> CreateProperties(IFormFileWrapper file)
        {
            yield return _propertyFactory.CreateProperty($"{_propertyName}[{file.FileName}].FileName", file.FileName);
            yield return _propertyFactory.CreateProperty($"{_propertyName}[{file.FileName}].Length", file.Length);
            yield return _propertyFactory.CreateProperty($"{_propertyName}[{file.FileName}].ContentType", file.ContentType);
        }
    }
}
