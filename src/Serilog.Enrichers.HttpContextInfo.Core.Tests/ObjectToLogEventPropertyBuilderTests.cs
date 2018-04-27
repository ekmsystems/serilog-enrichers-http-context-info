using System.Linq;
using Moq;
using NUnit.Framework;
using Serilog.Core;
using Serilog.Events;
using Serilog.Tests.Support;

namespace Serilog.Tests
{
    [TestFixture]
    [Parallelizable]
    public class ObjectToLogEventPropertyBuilderTests
    {
        [SetUp]
        public void SetUp()
        {
            _propertyFactory = new Mock<ILogEventPropertyFactory>();
            _propertyFactory
                .Setup(x => x.CreateProperty(It.IsAny<string>(), It.IsAny<object>(), false))
                .Returns((string name, object value, bool b) =>
                    new LogEventProperty(name, (LogEventPropertyValue) value));
        }

        private Mock<ILogEventPropertyFactory> _propertyFactory;

        [Test]
        public void Build_ShouldCreateLogEventProperties()
        {
            var builder = new ObjectToLogEventPropertyBuilder(_propertyFactory.Object, string.Empty);
            var obj = new {Name = "Trevor", Age = 25};
            
            var results = builder.GetLogEventProperties(obj).ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual("Name", results[0].Name);
            Assert.AreEqual("Trevor", results[0].Value.LiteralValue());
            Assert.AreEqual("Age", results[1].Name);
            Assert.AreEqual(25, results[1].Value.LiteralValue());
        }

        [Test]
        public void Build_WhenPrefixIsNotEmpty_ShouldCreateLogEventPropertiesWithPrefixedNames()
        {

            var builder = new ObjectToLogEventPropertyBuilder(_propertyFactory.Object, "MyPrefix");
            var obj = new { Name = "Trevor", Age = 25 };

            var results = builder.GetLogEventProperties(obj).ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual("MyPrefix.Name", results[0].Name);
            Assert.AreEqual("Trevor", results[0].Value.LiteralValue());
            Assert.AreEqual("MyPrefix.Age", results[1].Name);
            Assert.AreEqual(25, results[1].Value.LiteralValue());
        }
    }
}
