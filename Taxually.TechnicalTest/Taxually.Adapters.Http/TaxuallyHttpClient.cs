using Taxually.Ports.Outbound.Http;

namespace Taxually.Adapters.Http;

public class TaxuallyHttpClient : ITaxuallyHttpClient
{
    public Task PostAsync<TRequest>(string url, TRequest request)
    {
        return Task.CompletedTask;
    }
}