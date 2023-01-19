using Taxually.Core.VatRegistration.RegistrationStrategies.Abstractions;
using Taxually.Ports.Inbound.Vat;
using Taxually.Ports.Inbound.Vat.Interfaces;

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

        await registrationStrategy.HandleRequestAsync(vatRegistrationRequest);
    }
}