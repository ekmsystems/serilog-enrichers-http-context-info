using Microsoft.AspNetCore.Http;
using System.Web;

namespace Serilog
{
    public interface IFormFileWrapper
    {
        string FileName { get; }
        long Length { get; }
        string ContentType { get; }
    }

    internal class FormFileWrapper : IFormFileWrapper
    {
        private readonly IFormFile _formFile;

        public FormFileWrapper(IFormFile formFile)
        {
            _formFile = formFile;
        }

        public string FileName => _formFile.FileName;
        public long Length => _formFile.Length;
        public string ContentType => _formFile.ContentType;
    }
}
