using Taxually.Core.Models.VatRegistration;

namespace Taxually.Core.VatRegistration.RegistrationStrategies;

public interface IRegistrationStrategy
{
    public string StrategyCountryCode { get; set; }

    public Task HandleRequestAsync(IVatRegistrationRequest request);
}