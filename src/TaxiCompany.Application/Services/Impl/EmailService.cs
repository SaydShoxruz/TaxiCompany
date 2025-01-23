using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using TaxiCompany.Application.Common.Email;
using TaxiCompany.Application.Services.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public class EmailService : IEmailService
{

    private static readonly string[] Scopes = { GmailService.Scope.GmailSend };
    private const string ApplicationName = "GmailApiExample";

    private async static Task<UserCredential> GetCredentialsAsync()
    {
        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore("Gmail.Auth.Store"));
        }
    }

    public async static Task SendEmailAsync(string to, string subject, string body)
    {
        var credential = await GetCredentialsAsync();
        var service = new GmailService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });

        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Taxi Company", "saydshox123@gmail.com"));
        emailMessage.To.Add(new MailboxAddress("", to));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("plain") { Text = body };

        var rawMessage = Convert.ToBase64String(Encoding.UTF8.GetBytes(emailMessage.ToString()))
                          .Replace('+', '-')
                          .Replace('/', '_')
                          .Replace("=", "");

        var message = new Message { Raw = rawMessage };
        await service.Users.Messages.Send(message, "me").ExecuteAsync();
    }

    public void SendEmalDefault()
    {
        throw new NotImplementedException();
    }

    //private readonly SmtpSettings _smtpSettings;

    //public EmailService(SmtpSettings smtpSettings)
    //{
    //    _smtpSettings = smtpSettings;
    //}

    //public async Task SendEmailAsync(EmailMessage emailMessage)
    //{
    //    await SendAsync(CreateEmail(emailMessage));
    //}

    //private async Task SendAsync(MimeMessage message)
    //{
    //    using var client = new SmtpClient();

    //    try
    //    {
    //        await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
    //        client.AuthenticationMechanisms.Remove("XOAUTH2");
    //        await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

    //        await client.SendAsync(message);
    //    }
    //    catch
    //    {
    //        await client.DisconnectAsync(true);
    //        client.Dispose();

    //        throw;
    //    }
    //}

    //private MimeMessage CreateEmail(EmailMessage emailMessage)
    //{
    //    var builder = new BodyBuilder { HtmlBody = emailMessage.Body };

    //    if (emailMessage.Attachments.Count > 0)
    //        foreach (var attachment in emailMessage.Attachments)
    //            builder.Attachments.Add(attachment.Name, attachment.Value);

    //    var email = new MimeMessage
    //    {
    //        Subject = emailMessage.Subject,
    //        Body = builder.ToMessageBody()
    //    };

    //    email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
    //    email.To.Add(new MailboxAddress(emailMessage.ToAddress.Split("@")[0], emailMessage.ToAddress));

    //    return email;
    //}
}
