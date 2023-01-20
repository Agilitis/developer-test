using Taxually.Core.Models.VatRegistration;
using Taxually.Core.VatRegistration.RegistrationStrategies;
using Taxually.Ports.Outbound.Queue;

namespace Taxually.UnitTests.VatRegistration.RegistrationStrategies;

public class FrenchStrategyTests
{
    private ITaxuallyQueueClient _queueClient;

    [Test]
    public async Task HandleRequest_CallsHttpClientWithCsvReturnedByRequest()
    {
        _queueClient = Substitute.For<ITaxuallyQueueClient>();
        var frenchStrategy = new FrenchStrategy(_queueClient);
        var fakeRequest = Substitute.For<IVatRegistrationRequest>();
        var fakeCsv = new byte[1];
        fakeRequest.GetCsv().Returns(fakeCsv);
       
        await frenchStrategy.HandleRequestAsync(fakeRequest);
        
        await _queueClient.Received(1).EnqueueAsync(Arg.Any<string>(),
            Arg.Is<byte[]>(request => request == fakeCsv));
    }
}