using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Web;

namespace Serilog
{
    public interface IFormFileCollectionWrapper
    {
        string[] AllKeys { get; }

        IFormFileWrapper Get(string key);
    }

    internal class HttpFileCollectionWrapper : IFormFileCollectionWrapper
    {
        private readonly IFormFileCollection _formFileCollection;

        public HttpFileCollectionWrapper(IFormFileCollection formFileCollection)
        {
            _formFileCollection = formFileCollection;
        }

        public string[] AllKeys { get => _formFileCollection.Select(f => f.FileName).ToArray(); }

        public IFormFileWrapper Get(string key)
        {
            return new FormFileWrapper(_formFileCollection.GetFile(key));
        }
    }
}
