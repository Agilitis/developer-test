using Taxually.Ports.Outbound.Queue;

namespace Taxually.Adapters.Queue;

public class TaxuallyQueueClient : ITaxuallyQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload)
    {
        return Task.CompletedTask;
    }
}