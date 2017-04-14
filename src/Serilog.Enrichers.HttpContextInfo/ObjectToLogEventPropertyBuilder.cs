using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Serilog
{
    internal class ObjectToLogEventPropertyBuilder
    {
        private readonly ILogEventPropertyFactory _propertyFactory;
        private readonly string _prefix;

        public ObjectToLogEventPropertyBuilder(ILogEventPropertyFactory propertyFactory, string prefix)
        {
            _propertyFactory = propertyFactory;
            _prefix = prefix;
        }

        public IEnumerable<LogEventProperty> GetLogEventProperties<T>(T obj)
        {
            return obj == null
                ? Enumerable.Empty<LogEventProperty>()
                : typeof(T)
                    .GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance)
                    .Select(propertyInfo => CreateFromPropertyInfo(propertyInfo, obj));
        }

        private LogEventProperty CreateFromPropertyInfo(PropertyInfo propertyInfo, object obj)
        {
            var propertyName = GetPropertyName(propertyInfo);
            var value = GetPropertyValue(propertyInfo, obj);
            return _propertyFactory.CreateProperty(propertyName, new ScalarValue(value));
        }

        private string GetPropertyName(PropertyInfo propertyInfo)
        {
            return string.IsNullOrEmpty(_prefix) ? propertyInfo.Name : $"{_prefix}.{propertyInfo.Name}";
        }

        private static object GetPropertyValue(PropertyInfo propertyInfo, object obj)
        {
            try
            {
                return propertyInfo.GetValue(obj, null);
            }
            catch
            {
                return null;
            }
        }
    }
}
