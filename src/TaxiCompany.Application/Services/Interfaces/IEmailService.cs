using TaxiCompany.Application.Common.Email;

namespace TaxiCompany.Application.Services.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
