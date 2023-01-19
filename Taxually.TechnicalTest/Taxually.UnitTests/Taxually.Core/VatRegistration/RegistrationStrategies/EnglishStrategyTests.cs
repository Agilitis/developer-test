using Taxually.Core.VatRegistration.RegistrationStrategies;
using Taxually.Ports.Inbound.Vat;
using Taxually.Ports.Outbound.Http;

namespace Taxually.UnitTests.VatRegistration.RegistrationStrategies;

public class EnglishStrategyTests
{
    private ITaxuallyHttpClient _httpClient;

    [Test]
    public async Task HandleRequest_CallsHttpClientWithRegistrationRequest()
    {
        _httpClient = Substitute.For<ITaxuallyHttpClient>();
        var englishStrategy = new EnglishStrategy(_httpClient);
        var fakeRequest = new VatRegistrationRequest
        {
            CompanyName = "fakeCompany",
            Country = "fakeCountry",
            CompanyId = "1"
        };

        await englishStrategy.HandleRequestAsync(fakeRequest);

        await _httpClient.Received(1).PostAsync(Arg.Any<string>(),
            Arg.Is<VatRegistrationRequest>(request => request.Country == "fakeCountry" && 
                                                      request.CompanyId == "1" &&
                                                      request.CompanyName == "fakeCompany"));
    }
}