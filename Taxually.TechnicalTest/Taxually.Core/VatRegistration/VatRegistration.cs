using System.Text;
using System.Xml.Serialization;
using Taxually.Core.Models;
using Taxually.Core.VatRegistration.RegistrationStrategies;
using Taxually.Core.VatRegistration.RegistrationStrategies.Abstractions;
using Taxually.Ports.Inbound.Vat;
using Taxually.Ports.Inbound.Vat.Interfaces;
using Taxually.Ports.Outbound.Http;
using Taxually.Ports.Outbound.Queue;

namespace Taxually.Core.VatRegistration;

public class VatRegistration : IVatRegistration
{
    private readonly IReadOnlyCollection<IRegistrationStrategy> _registrationStrategies;

    public VatRegistration(IReadOnlyCollection<IRegistrationStrategy> registrationStrategies)
    {
        _registrationStrategies = registrationStrategies;
    }

    public async Task RegisterAsync(VatRegistrationRequest vatRegistrationRequest)
    {
        var registrationStrategy = _registrationStrategies.FirstOrDefault(strategy => strategy.StrategyCountryCode == vatRegistrationRequest.Country);
        if (registrationStrategy is null)
        {
            throw new Exception("Country not supported");
        }

        await registrationStrategy.HandleRequest(vatRegistrationRequest);
    }
}