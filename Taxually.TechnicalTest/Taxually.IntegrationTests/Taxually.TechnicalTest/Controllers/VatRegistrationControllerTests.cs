using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using Taxually.Ports.Inbound.Vat;
using Taxually.Ports.Inbound.Vat.Interfaces;
using Taxually.TechnicalTest.Controllers;

namespace Taxually.IntegrationTests.Taxually.TechnicalTest.Controllers;

public class VatRegistrationControllerTests : WebApplicationFactory<Program>
{
    private WebApplicationFactory<Program> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Test]
    public async Task VatRegistration_CanHandleRegistrationRequest()
    {
        var client = _factory.CreateClient();
        
        var vatRequest = new VatRegistrationRequest
        {
            Country = "GB",
            CompanyId = "1",
            CompanyName = "name"
        };

        var serializedRequest = JsonSerializer.Serialize(vatRequest);
        var vatRequestContent = new StringContent(
            serializedRequest,
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using var response = await client.PostAsync("api/VatRegistration/register", vatRequestContent);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}