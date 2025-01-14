using AutoMapper;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Models.Client;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;
    private readonly IUserRepository _userRepository;

    public ClientService(IMapper mapper,
        IClientRepository clientRepository,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<ClientResponseModel>> GetAllByPersonIdAsync(Guid id)
    {
        var client = await _clientRepository.GetAllAsync(cti => cti.User.Id == id);

        return _mapper.Map<IEnumerable<ClientResponseModel>>(client);
    }


    public async Task<CreateClientResponseModel> CreateAsync(CreateClientModel createClientModel,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.SelectByIdAsync(createClientModel.PersonId);

        var client = _mapper.Map<Client>(createClientModel);
        client.User = user;

        return new CreateClientResponseModel
        {
            Id = (await _clientRepository.AddAsync(client)).Id
        };
    }

    public async Task<UpdateClientResponseModel> UpdateAsync(Guid id, UpdateClientModel updateClientModel,
        CancellationToken cancellationToken = default)
    {
        var client = await _clientRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateClientModel, client);

        return new UpdateClientResponseModel
        {
            Id = (await _clientRepository.UpdateAsync(client)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var client = await _clientRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _clientRepository.DeleteAsync(client)).Id
        };
    }
}
