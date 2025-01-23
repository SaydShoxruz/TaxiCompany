using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxiCompany.API;
using TaxiCompany.API.Extensions;
using TaxiCompany.API.Filters;
using TaxiCompany.API.Middleware;
using TaxiCompany.Application;
using TaxiCompany.Application.Models.Validators;
using TaxiCompany.DataAccess;
using TaxiCompany.DataAccess.Authentication;
using TaxiCompany.DataAccess.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.AddLogging(builder.Configuration);

builder.Services
    .AddDbContexts(builder.Configuration)
    .AddAuthentication(builder.Configuration)
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

//var config = new MapperConfiguration(cfg =>
//{
//    cfg.AddProfile(new AutoMapperProfileConfiguration());
//});

//var mapper = config.CreateMapper();

//builder.Services.AddSingleton(mapper);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim(CustomClaimNames.Role, "Admin"));
    options.AddPolicy("Driver", policy =>
        policy.RequireClaim(CustomClaimNames.Role, "Driver"));
    options.AddPolicy("Client", policy =>
        policy.RequireClaim(CustomClaimNames.Role, "Client"));
});




builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(IValidationsMarker));

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);

builder.Services.AddEmailConfiguration(builder.Configuration);

var app = builder.Build();

using var scope = app.Services.CreateScope();


await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxiCompany V1"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

namespace TaxiCompany.API
{
    public partial class Program { }
}






//namespace TaxiCompany.API
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
