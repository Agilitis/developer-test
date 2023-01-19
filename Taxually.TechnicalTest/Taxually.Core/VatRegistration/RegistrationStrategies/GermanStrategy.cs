using System.Xml.Serialization;
using Taxually.Core.Models;
using Taxually.Core.VatRegistration.RegistrationStrategies.Abstractions;
using Taxually.Ports.Inbound.Vat;
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
    
    public async Task HandleRequest(VatRegistrationRequest request)
    {
        await using var stringWriter = new StringWriter();
        var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
        serializer.Serialize(stringWriter, this);
        var xml = stringWriter.ToString();
        await _queueClient.EnqueueAsync("vat-registration-xml", xml);
    }
}