using Taxually.Ports.Inbound.Vat;

namespace Taxually.Core.VatRegistration.RegistrationStrategies.Abstractions;

public interface IRegistrationStrategy
{
    public string StrategyCountryCode { get; set; }

    public Task HandleRequestAsync(VatRegistrationRequest request);
}