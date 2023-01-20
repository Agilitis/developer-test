namespace Taxually.Ports.Inbound.VatRegistration.Models;

public record VatRegistrationRequest
{
    public string CompanyName { get; init; }
    
    public string CompanyId { get; init; }
    
    public string Country { get; init; }
}