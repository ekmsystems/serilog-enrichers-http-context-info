using System;
using System.Linq;
using System.Web;
using Moq;
using NUnit.Framework;
using Serilog.Converters;
using Serilog.Core;

namespace Serilog.Tests.Converters
{
    [TestFixture]
    [Parallelizable]
    public class HttpCookieCollectionLogEventPropertyConverterTests
    {
        [SetUp]
        public void SetUp()
        {
            _propertyFactory = new Mock<ILogEventPropertyFactory>();
            _converter = new HttpCookieCollectionLogEventPropertyConverter(_propertyFactory.Object, PropertyName);
        }

        private const string PropertyName = "MyCollection";
        private Mock<ILogEventPropertyFactory> _propertyFactory;
        private ILogEventPropertyConverter<HttpCookieCollection> _converter;

        [Test]
        public void Convert_ShouldReturn_LogEventProperties()
        {
            var expires = new DateTime(2017, 1, 1);
            var collection = new HttpCookieCollection
            {
                new HttpCookie("Test", "value") {Domain = "localhost", Expires = expires, Path = "/"}
            };

            var results = _converter.Convert(collection).ToArray();

            Assert.AreEqual(5, results.Length);

            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[Test].Name", "Test", false), Times.Once);
            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[Test].Value", "value", false), Times.Once);
            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[Test].Domain", "localhost", false), Times.Once);
            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[Test].Expires", expires.ToString("u"), false), Times.Once);
            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[Test].Path", "/", false), Times.Once);
        }
    }
}
