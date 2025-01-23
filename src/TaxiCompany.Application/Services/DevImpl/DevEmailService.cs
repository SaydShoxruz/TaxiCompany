using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Text;
using TaxiCompany.Application.Common.Email;
using TaxiCompany.Application.Services.Interfaces;
using System.Net.Mail;
using System.Net;

namespace TaxiCompany.Application.Services.DevImpl;

public class DevEmailService : IEmailService
{
    private readonly ILogger<DevEmailService> _logger;

    public DevEmailService(ILogger<DevEmailService> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        await Task.Delay(100);

        _logger.LogInformation($"Email was sent to: [{emailMessage.ToAddress}]. Body: {emailMessage.Body}");
    }

    public void SendEmalDefault()
    {
        try
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("saydshox123@gmail.com", "Taxi Company");
            message.To.Add("tursunmurodovasevinch9@gmail.com");
            message.Subject = "Сообщение от Такси Компании";
            message.Body = "<div style=\"color: red;\"Сообщение от Такси Компании</div>";

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            {

                smtpClient.Credentials = new NetworkCredential("saydshox123@gmail.com", "gbbh vsga ijna wjqj");
                smtpClient.Port = 465;
                smtpClient.EnableSsl = true;

                smtpClient.Send(message);
                Console.WriteLine("Сообщение успешно отправлено!");

            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.GetBaseException().Message);
        }
    }
}
