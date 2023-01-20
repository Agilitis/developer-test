using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using Taxually.Core.Models.VatRegistration;

namespace Taxually.UnitTests.Taxually.Core.Models.VatRegistration;

public class VatRegistrationRequestTests
{
    [Test]
    public async Task GetXmlAsync_ReturnsXmlFromRequestData()
    {
        var request = new VatRegistrationRequest
        {
            CompanyId = "31412",
            CompanyName = "myFakeCompany"
        };

        var xml = await request.GetXmlAsync();

        using var assertionScope = new AssertionScope();
        xml.Should().Contain("31412");
        xml.Should().Contain("myFakeCompany");
    }
    
    [Test]
    public async Task GetCsv_ReturnsXmlFromRequestData()
    {
        var request = new VatRegistrationRequest
        {
            CompanyId = "31412",
            CompanyName = "myFakeCompany"
        };

        var csv = Encoding.UTF8.GetString(request.GetCsv());

        using var assertionScope = new AssertionScope();
        csv.Should().Contain("31412");
        csv.Should().Contain("myFakeCompany");
    }
}