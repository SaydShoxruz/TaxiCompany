namespace TaxiCompany.Application.Models.Card;

public class UpdateCarsOwnerModel
{
    public bool IsVerified { get; set; }

    public decimal Balance { get; set; }
}

public class UpdateCardResponseModel : BaseResponseModel { }
