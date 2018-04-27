using System;
using System.Linq;
using System.Web;
using Moq;
using NUnit.Framework;
using Serilog.Core;
using Serilog.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;

namespace Serilog.Tests.Converters
{
    [TestFixture]
    [Parallelizable]
    public class RequestCookieCollectionLogEventPropertyConverterTests
    {
        [SetUp]
        public void SetUp()
        {
            _propertyFactory = new Mock<ILogEventPropertyFactory>();
            _converter = new RequestCookieCollectionLogEventPropertyConverter(_propertyFactory.Object, PropertyName);
        }

        private const string PropertyName = "MyCollection";
        private Mock<ILogEventPropertyFactory> _propertyFactory;
        private ILogEventPropertyConverter<IRequestCookieCollection> _converter;

        [Test]
        public void Convert_ShouldReturn_LogEventProperties()
        {
            var collection = new RequestCookieCollection(new Dictionary<string, string> { { "Test", "value" } });

            var results = _converter.Convert(collection).ToArray();

            Assert.AreEqual(1, results.Length);

            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[Test]", "value", false), Times.Once);
        }
    }
}
