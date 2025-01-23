using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Services.DevImpl;
using TaxiCompany.Application.Services.Interfaces;

namespace TaxiCompany.API.Controllers
{
    public class SendEmailMessageController : ApiController
    {

        private readonly IEmailService devEmailService;
        public SendEmailMessageController(IEmailService devEmailService)
        {
            this.devEmailService = devEmailService;
        }

        [HttpPost]
        public IActionResult SendMessage()
        {
            devEmailService.SendEmalDefault();
            return Ok();
        }

    }
}
