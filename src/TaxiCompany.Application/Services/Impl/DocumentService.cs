using AutoMapper;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Document;
using TaxiCompany.Application.Services.Interfaces;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.Application.Services.Impl;

public class DocumentService : IDocumentService
{
    private readonly IMapper _mapper;
    private readonly IDocumentRepository _documentRepository;
    private readonly IUserRepository _userRepository;

    public DocumentService(IMapper mapper,
        IDocumentRepository documentRepository,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _documentRepository = documentRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<DocumentResponseModel>> GetAllByPersonId(Guid id)
    {
        var documents = _documentRepository.GetAllAsync(cti => cti.User.Id == id);

        return _mapper.Map<IEnumerable<DocumentResponseModel>>(documents);
    }

    public async Task<CreateDocumentResponseModel> CreateAsync(CreateDocumentModel createDocumentModel)
    {
        var user = await _userRepository.SelectByIdAsync(createDocumentModel.UserId);

        var document = _mapper.Map<Document>(createDocumentModel);
        document.User = user;

        return new CreateDocumentResponseModel()
        {
            Id = (await _documentRepository.AddAsync(document)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var document = await _documentRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _documentRepository.DeleteAsync(document)).Id
        };
    }
}
