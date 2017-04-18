using System.Web;

namespace Serilog
{
    public interface IHttpFileCollectionWrapper
    {
        string[] AllKeys { get; }

        IHttpPostedFileWrapper Get(string key);
    }

    internal class HttpFileCollectionWrapper : IHttpFileCollectionWrapper
    {
        private readonly HttpFileCollection _httpFileCollection;

        public HttpFileCollectionWrapper(HttpFileCollection httpFileCollection)
        {
            _httpFileCollection = httpFileCollection;
        }

        public string[] AllKeys => _httpFileCollection.AllKeys;

        public IHttpPostedFileWrapper Get(string key)
        {
            return new HttpPostedFileWrapper(_httpFileCollection.Get(key));
        }
    }
}
