using System.Web;

namespace Serilog
{
    public interface IHttpPostedFileWrapper
    {
        string FileName { get; }
        int ContentLength { get; }
        string ContentType { get; }
    }

    internal class HttpPostedFileWrapper : IHttpPostedFileWrapper
    {
        private readonly HttpPostedFile _httpPostedFile;

        public HttpPostedFileWrapper(HttpPostedFile httpPostedFile)
        {
            _httpPostedFile = httpPostedFile;
        }

        public string FileName => _httpPostedFile.FileName;
        public int ContentLength => _httpPostedFile.ContentLength;
        public string ContentType => _httpPostedFile.ContentType;
    }
}
