using System.Text;
using System.Xml.Serialization;
using Taxually.Ports.Inbound.Vat;
using Taxually.Ports.Inbound.Vat.Interfaces;
using Taxually.TechnicalTest;

namespace Taxually.Core.VatRegistration;

public class VatRegistration : IVatRegistration
{
    public async Task RegisterAsync(VatRegistrationRequest vatRegistrationRequest)
    {
        switch (vatRegistrationRequest.Country)
        {
            case "GB":
                // UK has an API to register for a VAT number
                var httpClient = new TaxuallyHttpClient();
                httpClient.PostAsync("https://api.uktax.gov.uk", vatRegistrationRequest).Wait();
                break;
            case "FR":
                // France requires an excel spreadsheet to be uploaded to register for a VAT number
                var csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("CompanyName,CompanyId");
                csvBuilder.AppendLine($"{vatRegistrationRequest.CompanyName}{vatRegistrationRequest.CompanyId}");
                var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
                var excelQueueClient = new TaxuallyQueueClient();
                // Queue file to be processed
                await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
                break;
            case "DE":
                // Germany requires an XML document to be uploaded to register for a VAT number
                await using (var stringWriter = new StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                    serializer.Serialize(stringWriter, this);
                    var xml = stringWriter.ToString();
                    var xmlQueueClient = new TaxuallyQueueClient();
                    // Queue xml doc to be processed
                    await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
                }
                break;
            default:
                throw new Exception("Country not supported");
        }
    }
}