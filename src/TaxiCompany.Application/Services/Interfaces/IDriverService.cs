using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Services.Interfaces;

public interface IDriverService
{
    Task<CreateCarsOwnerResponseModel> CreateAsync(CreateDriverModel createCarsOwnerModel, CancellationToken cancellationToken = default);
    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<DriverResponseModel>> GetAllByPersonIdAsync(Guid id);
}
