namespace TaxiCompany.Application.Models.CarsOwner;

public class CreateDriverModel
{
    public Guid UserId { get; set; }

    public decimal CompanyWallet { get; set; }
}

public class CreateCarsOwnerResponseModel : BaseResponseModel { }