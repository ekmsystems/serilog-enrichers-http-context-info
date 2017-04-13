namespace Serilog
{
    public interface IHttpContextWrapper
    {
        IHttpRequestWrapper Request { get; }
        IHttpResponseWrapper Response { get; }
    }
}