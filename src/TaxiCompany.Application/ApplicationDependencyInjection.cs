using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiCompany.Shared.Services.Impl;
using TaxiCompany.Shared.Services;
using TaxiCompany.Application.Common.Email;
using TaxiCompany.Application.MappingProfiles;
using TaxiCompany.Application.Services.DevImpl;
using TaxiCompany.Application.Services.Impl;
using TaxiCompany.Application.Services.Interfaces;

namespace TaxiCompany.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IImpressionsService, ImpressionsService>();
        services.AddScoped<IInsuranceService, InsuranceService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ITripService, TripService>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<IUserFactory, UserFactory>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IEmailService, DevEmailService>();


        //if (env.IsDevelopment())
        //    services.AddScoped<IEmailService, DevEmailService>();
        //else
        //    services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}
