using System.Text;
using System.Web;
using NUnit.Framework;

namespace Serilog.Tests
{
    [TestFixture]
    [Parallelizable]
    public class HttpRequestWrapperTests
    {
        [Test]
        public void ShouldUseHttpRequestProperties()
        {
            var request = new HttpRequest("test", "http://serilog.net/", "test=1") {ContentEncoding = Encoding.UTF32};

            var wrapper = new HttpRequestWrapper(request);

            Assert.AreEqual(request.AnonymousID, wrapper.AnonymousID);
            Assert.AreEqual(request.ApplicationPath, wrapper.ApplicationPath);
            Assert.AreEqual(request.ContentEncoding, wrapper.ContentEncoding);
            Assert.AreEqual(request.ContentLength, wrapper.ContentLength);
            Assert.AreEqual(request.ContentType, wrapper.ContentType);
            Assert.AreEqual(request.CurrentExecutionFilePath, wrapper.CurrentExecutionFilePath);
            Assert.AreEqual(request.CurrentExecutionFilePathExtension, wrapper.CurrentExecutionFilePathExtension);
            Assert.AreEqual(request.FilePath, wrapper.FilePath);
            Assert.AreEqual(request.RawUrl, wrapper.RawUrl);
            Assert.AreEqual(request.Url, wrapper.Url);
        }
    }
}