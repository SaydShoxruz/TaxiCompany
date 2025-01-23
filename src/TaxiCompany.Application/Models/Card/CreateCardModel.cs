namespace TaxiCompany.Application.Models.Card;

public class CreateCardModel
{
    public string Num { get; set; }

    public string Term { get; set; }

    public Guid UserId { get; set; }

}

public class CreateCardResponseModel : BaseResponseModel { }
