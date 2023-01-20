using Taxually.Core.Models;
using Taxually.Core.Models.VatRegistration;
using Taxually.Ports.Outbound.Http;

namespace Taxually.Core.VatRegistration.RegistrationStrategies;

public class EnglishStrategy : IRegistrationStrategy
{
    private readonly ITaxuallyHttpClient _httpClient;

    public EnglishStrategy(ITaxuallyHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string StrategyCountryCode { get; set; } = CountryCodes.England;
    
    public async Task HandleRequestAsync(IVatRegistrationRequest request)
    {
        await _httpClient.PostAsync("https://api.uktax.gov.uk", request);
    }
}