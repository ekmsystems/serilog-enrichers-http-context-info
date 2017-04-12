using System.IO;
using System.Web;
using NUnit.Framework;

namespace Serilog.Tests.Enrichers
{
    [TestFixture]
    [Parallelizable]
    public class AnonymousIdEnricherTests
    {
        [SetUp]
        public void SetUp()
        {
            HttpContext.Current = new HttpContext(
                new HttpRequest("test", "https://serilog.net/my-app", ""),
                new HttpResponse(new StringWriter()));
        }
    }
}
