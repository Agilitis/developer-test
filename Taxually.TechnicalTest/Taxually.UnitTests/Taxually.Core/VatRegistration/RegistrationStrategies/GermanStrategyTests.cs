using Taxually.Core.Models.VatRegistration;
using Taxually.Core.VatRegistration.RegistrationStrategies;
using Taxually.Ports.Outbound.Queue;

namespace Taxually.UnitTests.VatRegistration.RegistrationStrategies;

public class GermanStrategyTests
{
    private ITaxuallyQueueClient _queueClient;

    [Test]
    public async Task HandleRequest()
    {
        _queueClient = Substitute.For<ITaxuallyQueueClient>();
        var germanStrategy = new GermanStrategy(_queueClient);
        var fakeRequest = Substitute.For<IVatRegistrationRequest>();
        fakeRequest.GetXmlAsync().Returns("test");
       
        await germanStrategy.HandleRequestAsync(fakeRequest);
        
        await _queueClient.Received(1).EnqueueAsync(Arg.Any<string>(),
            Arg.Is<string>(request => request == "test"));
        
    }
}