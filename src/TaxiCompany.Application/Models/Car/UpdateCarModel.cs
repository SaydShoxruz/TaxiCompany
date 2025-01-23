using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.Models.Car;

public class UpdateCarModel
{
    public bool IsFree { get; set; }

    public Guid DriversId { get; set; }


}

public class UpdateCarResponseModel : BaseResponseModel { };
