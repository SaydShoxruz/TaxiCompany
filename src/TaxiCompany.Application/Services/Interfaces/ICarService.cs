﻿using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Car;
using TaxiCompany.Application.Models.Card;

namespace TaxiCompany.Application.Services;

public interface ICarService
{
    Task<CreateCarResponseModel> CreateAsync(CreateCarModel createCarModel, CancellationToken cancellationToken = default);
    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CarResponseModel> GetCarById(Guid id);
    Task<UpdateCarResponseModel> UpdateAsync(Guid id, UpdateCarsOwnerModel updateCardModel, CancellationToken cancellationToken = default);
}