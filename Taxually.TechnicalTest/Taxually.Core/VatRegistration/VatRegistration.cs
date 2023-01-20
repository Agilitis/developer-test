using System.Text;
using Taxually.Core.VatRegistration.RegistrationStrategies;
using Taxually.Ports.Inbound.Vat.Interfaces;
using Taxually.Ports.Inbound.VatRegistration.Models;

namespace Taxually.Core.VatRegistration;

public class VatRegistration : IVatRegistration
{
    private readonly IEnumerable<IRegistrationStrategy> _registrationStrategies;

    public VatRegistration(IEnumerable<IRegistrationStrategy> registrationStrategies)
    {
        _registrationStrategies = registrationStrategies;
    }

    public async Task RegisterAsync(VatRegistrationRequest vatRegistrationRequest)
    {
        var registrationStrategy = _registrationStrategies.FirstOrDefault(strategy => strategy.StrategyCountryCode == vatRegistrationRequest.Country);
        if (registrationStrategy is null)
        {
            throw new Exception("Country not supported");
        }

        var coreRegistrationRequest = new Models.VatRegistration.VatRegistrationRequest()
        {
            CompanyId = vatRegistrationRequest.CompanyId,
            CompanyName = vatRegistrationRequest.CompanyName
        };

        await registrationStrategy.HandleRequestAsync(coreRegistrationRequest);
    }

    public byte[] GetCsvFor(VatRegistrationRequest request)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        return csv;
    }
}