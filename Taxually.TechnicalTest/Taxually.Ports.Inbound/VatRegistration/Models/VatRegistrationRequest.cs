namespace Taxually.Ports.Inbound.Vat;

public record VatRegistrationRequest
{
    public string CompanyName { get; }
    
    public string CompanyId { get; }
    
    public string Country { get; }
}