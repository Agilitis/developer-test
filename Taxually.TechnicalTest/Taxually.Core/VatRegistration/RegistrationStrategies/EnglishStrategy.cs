using Taxually.Core.Models;
using Taxually.Core.VatRegistration.RegistrationStrategies.Abstractions;
using Taxually.Ports.Inbound.Vat;
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
    
    public async Task HandleRequest(VatRegistrationRequest request)
    {
        await _httpClient.PostAsync("https://api.uktax.gov.uk", request);
    }
}