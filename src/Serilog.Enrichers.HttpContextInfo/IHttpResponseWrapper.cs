using System.IO;

namespace Serilog
{
    public interface IHttpResponseWrapper
    {
        TextWriter Output { get; }
    }
}