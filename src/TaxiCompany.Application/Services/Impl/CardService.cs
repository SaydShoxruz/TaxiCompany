﻿using AutoMapper;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models.Car;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public class CardService : ICardService
{
    private IMapper _mapper;
    private ICardRepository _cardRepository;
    private IUserRepository _userRepository;

    public CardService(IMapper mapper,
        ICardRepository cardRepository,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<CardResponseModel>> GetAllByPersonIdAsync(Guid id)
    {
        var cards = _cardRepository.GetFirstAsync(cti => cti.User.Id == id);

        return _mapper.Map<IEnumerable<CardResponseModel>>(cards);
    }


    public async Task<CreateCardResponseModel> CreateAsync(CreateCardModel createCardModel,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.SelectByIdAsync(createCardModel.UserId);

        var card = _mapper.Map<Card>(createCardModel);
        card.User = user;

        return new CreateCardResponseModel
        {
            Id = (await _cardRepository.AddAsync(card)).Id
        };
    }

    public async Task<UpdateCardResponseModel> UpdateAsync(Guid id, UpdateCarsOwnerModel updateCardModel,
        CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateCardModel, card);

        return new UpdateCardResponseModel
        {
            Id = (await _cardRepository.UpdateAsync(card)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _cardRepository.DeleteAsync(card)).Id
        };
    }
}
