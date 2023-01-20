using System.Text;
using System.Xml.Serialization;

namespace Taxually.Core.Models.VatRegistration;

public class VatRegistrationRequest : IVatRegistrationRequest
{
    public string CompanyName { get; init; }
    
    public string CompanyId { get; init; }

    public async Task<string> GetXmlAsync()
    {
        await using var stringWriter = new StringWriter();
        var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
        serializer.Serialize(stringWriter, this);
        var xml = stringWriter.ToString();
        return xml;
    }
    
    public byte[] GetCsv()
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{this.CompanyName}{this.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        return csv;
    }
}