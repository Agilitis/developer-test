namespace Taxually.Ports.Outbound.Queue;

public interface ITaxuallyQueueClient
{
    public Task EnqueueAsync<TPayload>(string queueName, TPayload payload);
}