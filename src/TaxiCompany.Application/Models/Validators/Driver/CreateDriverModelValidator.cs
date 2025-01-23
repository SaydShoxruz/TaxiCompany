using FluentValidation;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Application.Models.Validators.Card;

namespace TaxiCompany.Application.Models.Validators.CarsOwner;

public class CreateDriverModelValidator : AbstractValidator<CreateDriverModel>
{
    public CreateDriverModelValidator()
    {
        RuleFor(cti => cti.CompanyWallet)
            .GreaterThanOrEqualTo(DriverValidatorConfiguration.MinCompanyWalletValue)
            .WithMessage($"Minimum Value for Company Wallet - {DriverValidatorConfiguration.MinCompanyWalletValue}");
    }
}
