namespace TaxiCompany.Application.Models.Car;

public class CreateCarModel
{
    public string Model { get; set; }

    public Guid DriversId { get; set; }

}

public class CreateCarResponseModel : BaseResponseModel { };
