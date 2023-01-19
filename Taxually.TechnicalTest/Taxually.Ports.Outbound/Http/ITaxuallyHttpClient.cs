namespace Taxually.Ports.Outbound.Http;

public interface ITaxuallyHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request);
}