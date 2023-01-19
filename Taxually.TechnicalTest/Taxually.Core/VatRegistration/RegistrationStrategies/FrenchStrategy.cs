using System.Text;
using Taxually.Core.Models;
using Taxually.Core.VatRegistration.RegistrationStrategies.Abstractions;
using Taxually.Ports.Inbound.Vat;
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
    
    public async Task HandleRequest(VatRegistrationRequest request)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        await _queueClient.EnqueueAsync("vat-registration-csv", csv);
    }
}