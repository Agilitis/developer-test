using Microsoft.Extensions.DependencyInjection;
using Taxually.Ports.Outbound.Queue;

namespace Taxually.Adapters.Queue;

public static class QueueClientServiceRegistrations
{
    public static IServiceCollection AddQueueClientServices(this IServiceCollection services)
    {
        services.AddTransient<ITaxuallyQueueClient, TaxuallyQueueClient>();
        return services;
    }
}