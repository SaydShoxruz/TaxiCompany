using FluentValidation;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Models.Validators.CarsOwner;

public class UpdateDriverModelValidator : AbstractValidator<UpdateDriverModel>
{
    public UpdateDriverModelValidator()
    {
        RuleFor(cti => cti.Priority)
            .GreaterThanOrEqualTo(DriverValidatorConfiguration.MinPriorityValue)
            .WithMessage($"Minimum Value for Priority - {DriverValidatorConfiguration.MinPriorityValue}")
            .LessThanOrEqualTo(DriverValidatorConfiguration.MaxPriorityValue)
            .WithMessage($"Maximum Value for Priority - {DriverValidatorConfiguration.MinPriorityValue}");

        RuleFor(cti => cti.Rating)
            .GreaterThanOrEqualTo(DriverValidatorConfiguration.MinRatingValue)
            .WithMessage($"Minimum Value for Rating - {DriverValidatorConfiguration.MinRatingValue}")
            .LessThanOrEqualTo(DriverValidatorConfiguration.MaxRatingValue)
            .WithMessage($"Maximum Value for Rating - {DriverValidatorConfiguration.MaxRatingValue}");

        RuleFor(cti => cti.CompanyWallet)
            .GreaterThanOrEqualTo(DriverValidatorConfiguration.MinCompanyWalletValue)
            .WithMessage($"Minimum Value for Company Wallet - {DriverValidatorConfiguration.MaxRatingValue}");
    }
}
