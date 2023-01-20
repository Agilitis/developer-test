using Taxually.Core.Models;
using Taxually.Core.Models.VatRegistration;
using Taxually.Ports.Outbound.Queue;

namespace Taxually.Core.VatRegistration.RegistrationStrategies;

public class FrenchStrategy : IRegistrationStrategy
{
    private readonly ITaxuallyQueueClient _queueClient;

    public FrenchStrategy(ITaxuallyQueueClient queueClient)
    {
        _queueClient = queueClient;
    }

    public string StrategyCountryCode { get; set; } = CountryCodes.France;
    
    public async Task HandleRequestAsync(IVatRegistrationRequest request)
    {
        var csv = request.GetCsv();
        
        await _queueClient.EnqueueAsync("vat-registration-csv", csv);
    }
}