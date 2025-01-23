using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using AutoMapper;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public class DriverService : IDriverService
{

    private IMapper _mapper;
    private IDriverRepository _carsOwnerRepository;
    private IUserRepository _userRepository;

    public DriverService(IMapper mapper,
        IDriverRepository carsOwnerRepository,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _carsOwnerRepository = carsOwnerRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<DriverResponseModel>> GetAllByPersonIdAsync(Guid id)
    {
        var carsOwners = await _carsOwnerRepository.GetAllAsync(cti => cti.User.Id == id);

        return _mapper.Map<IEnumerable<DriverResponseModel>>(carsOwners);
    }


    public async Task<CreateCarsOwnerResponseModel> CreateAsync(CreateDriverModel createCarsOwnerModel,
        CancellationToken cancellationToken = default)
    {
        var person = await _userRepository.SelectByIdAsync(createCarsOwnerModel.UserId);

        var carsOwner = _mapper.Map<Driver>(createCarsOwnerModel);
        carsOwner.User = person;

        return new CreateCarsOwnerResponseModel
        {
            Id = (await _carsOwnerRepository.AddAsync(carsOwner)).Id
        };
    }
    // Как обновляется по айди, хотя там класс
    public async Task<UpdateCarsOwnerResponseModel> UpdateAsync(Guid id, Models.Card.UpdateCarsOwnerModel updateCardModel,
        CancellationToken cancellationToken = default)
    {
        var card = await _carsOwnerRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateCardModel, card);

        return new UpdateCarsOwnerResponseModel
        {
            Id = (await _carsOwnerRepository.UpdateAsync(card)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var carsOwner = await _carsOwnerRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _carsOwnerRepository.DeleteAsync(carsOwner)).Id
        };
    }
}
