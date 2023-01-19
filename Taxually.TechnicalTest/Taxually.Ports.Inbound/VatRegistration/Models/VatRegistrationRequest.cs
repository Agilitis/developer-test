namespace Taxually.Ports.Inbound.Vat;

public record VatRegistrationRequest
{
    public string CompanyName { get; init; }
    
    public string CompanyId { get; init; }
    
    public string Country { get; init; }
}