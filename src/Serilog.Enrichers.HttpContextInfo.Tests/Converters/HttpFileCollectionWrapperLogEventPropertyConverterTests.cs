using System.Linq;
using Moq;
using NUnit.Framework;
using Serilog.Converters;
using Serilog.Core;

namespace Serilog.Tests.Converters
{
    [TestFixture]
    [Parallelizable]
    public class HttpFileCollectionWrapperLogEventPropertyConverterTests
    {
        [SetUp]
        public void SetUp()
        {
            _propertyFactory = new Mock<ILogEventPropertyFactory>();
            _converter = new HttpFileCollectionWrapperLogEventPropertyConverter(_propertyFactory.Object, PropertyName);
        }

        private const string PropertyName = "MyCollection";
        private Mock<ILogEventPropertyFactory> _propertyFactory;
        private ILogEventPropertyConverter<IHttpFileCollectionWrapper> _converter;

        [Test]
        public void Convert_ShouldReturn_LogEventProperties()
        {
            var file = new Mock<IHttpPostedFileWrapper>();
            var collection = new Mock<IHttpFileCollectionWrapper>();

            file.SetupGet(x => x.FileName).Returns("test.png");
            file.SetupGet(x => x.ContentLength).Returns(100);
            file.SetupGet(x => x.ContentType).Returns("binary");
            collection.Setup(x => x.AllKeys).Returns(new[] {file.Object.FileName});
            collection.Setup(x => x.Get(file.Object.FileName)).Returns(file.Object);

            var results = _converter.Convert(collection.Object).ToArray();

            Assert.AreEqual(3, results.Length);

            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[test.png].FileName", "test.png", false), Times.Once);
            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[test.png].ContentLength", 100, false), Times.Once);
            _propertyFactory
                .Verify(x => x.CreateProperty($"{PropertyName}[test.png].ContentType", "binary", false), Times.Once);
        }
    }
}
