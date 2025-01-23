using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Common.Email;
using TaxiCompany.Application.Services.Impl;

namespace TaxiCompany.API.Controllers;

public class EmailController : ApiController
{
    //[HttpPost("send")]
    //public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
    //{
    //    if (string.IsNullOrEmpty(emailRequest.To) || string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.Body))
    //    {
    //        return BadRequest("Email fields are required.");
    //    }

    //    await EmailService.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.Body);
    //    return Ok("Email sent successfully.");
    //}

}
