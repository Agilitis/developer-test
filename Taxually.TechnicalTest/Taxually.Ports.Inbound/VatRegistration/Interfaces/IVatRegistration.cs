using Taxually.Ports.Inbound.VatRegistration.Models;

namespace Taxually.Ports.Inbound.Vat.Interfaces;

public interface IVatRegistration
{
    public Task RegisterAsync(VatRegistrationRequest vatRegistrationRequest);
}