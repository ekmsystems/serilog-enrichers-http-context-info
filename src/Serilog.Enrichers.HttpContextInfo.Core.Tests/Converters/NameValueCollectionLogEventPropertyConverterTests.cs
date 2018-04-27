using System.Collections.Specialized;
using System.Linq;
using Moq;
using NUnit.Framework;
using Serilog.Converters;
using Serilog.Core;

namespace Serilog.Tests.Converters
{
    [TestFixture]
    [Parallelizable]
    public class NameValueCollectionLogEventPropertyConverterTests
    {
        //[SetUp]
        //public void SetUp()
        //{
        //    _propertyFactory = new Mock<ILogEventPropertyFactory>();
        //    _converter = new NameValueCollectionLogEventPropertyConverter(_propertyFactory.Object, PropertyName);
        //}

        //private const string PropertyName = "MyCollection";
        //private Mock<ILogEventPropertyFactory> _propertyFactory;
        //private ILogEventPropertyConverter<NameValueCollection> _converter;

        //[Test]
        //public void Convert_ShouldReturn_LogEventProperties()
        //{
        //    var collection = new NameValueCollection
        //    {
        //        {"Test", "value"}
        //    };

        //    var results = _converter.Convert(collection).ToArray();

        //    Assert.AreEqual(1, results.Length);

        //    _propertyFactory.Verify(x => x.CreateProperty($"{PropertyName}[Test]", "value", false), Times.Once);
        //}
    }
}
