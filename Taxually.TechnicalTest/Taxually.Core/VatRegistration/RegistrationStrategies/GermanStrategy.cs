using Taxually.Core.Models;
using Taxually.Core.Models.VatRegistration;
using Taxually.Ports.Outbound.Queue;

namespace Taxually.Core.VatRegistration.RegistrationStrategies;

public class GermanStrategy : IRegistrationStrategy
{
    private readonly ITaxuallyQueueClient _queueClient;

    public GermanStrategy(ITaxuallyQueueClient queueClient)
    {
        _queueClient = queueClient;
    }

    public string StrategyCountryCode { get; set; } = CountryCodes.Germany;
    
    public async Task HandleRequestAsync(IVatRegistrationRequest request)
    {
        var xml = await request.GetXmlAsync();
        
        await _queueClient.EnqueueAsync("vat-registration-xml", xml);
    }
}