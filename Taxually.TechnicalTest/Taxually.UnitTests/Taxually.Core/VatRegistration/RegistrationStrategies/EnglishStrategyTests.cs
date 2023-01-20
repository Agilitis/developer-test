using Taxually.Core.Models.VatRegistration;
using Taxually.Core.VatRegistration.RegistrationStrategies;
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
            CompanyId = "1",
            CompanyName = "fakeCompany"
        };
        
        await englishStrategy.HandleRequestAsync(fakeRequest);

        await _httpClient.Received(1).PostAsync(Arg.Any<string>(),
            Arg.Is<IVatRegistrationRequest>(request => request.CompanyId == "1" &&
                                                      request.CompanyName == "fakeCompany"));
    }
}