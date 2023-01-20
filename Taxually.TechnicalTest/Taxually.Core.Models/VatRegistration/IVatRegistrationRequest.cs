namespace Taxually.Core.Models.VatRegistration;

public interface IVatRegistrationRequest
{
    public string CompanyName { get; init; }
    
    public string CompanyId { get; init; }
    
    public Task<string> GetXmlAsync();

    public byte[] GetCsv();
}