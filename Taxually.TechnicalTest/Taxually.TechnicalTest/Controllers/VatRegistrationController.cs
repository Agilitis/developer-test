using Microsoft.AspNetCore.Mvc;
using Taxually.Ports.Inbound.Vat.Interfaces;
using Taxually.Ports.Inbound.VatRegistration.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/VatRegistration")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistration _vatRegistration;

        public VatRegistrationController(IVatRegistration vatRegistration)
        {
            _vatRegistration = vatRegistration;
        }

        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            await _vatRegistration.RegisterAsync(request);
            return Ok();
        }
    }
}
