namespace PruebaBackend_Javier.Repository;

public interface IHttpService
{
    Task<string> ConsumeServices(string? body, string url, HttpMethod method, Dictionary<string, string> headers);
}