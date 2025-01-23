namespace TaxiCompany.Application.Models.CarsOwner;

public class UpdateDriverModel
{
    public int Priority { get; set; }

    public decimal Rating { get; set; }

    public decimal CompanyWallet { get; set; }
}

public class UpdateCarsOwnerResponseModel : BaseResponseModel { }
