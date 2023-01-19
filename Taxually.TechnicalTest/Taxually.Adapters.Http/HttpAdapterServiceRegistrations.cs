using Microsoft.Extensions.DependencyInjection;
using Taxually.Ports.Outbound.Http;

namespace Taxually.Adapters.Http;

public static class HttpAdapterServiceRegistrations
{
    public static IServiceCollection AddHttpAdapterServices(this IServiceCollection services)
    {
        services.AddTransient<ITaxuallyHttpClient, TaxuallyHttpClient>();
        return services;
    }
}