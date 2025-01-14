using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Document;

namespace TaxiCompany.Application.Services.Interfaces;

public interface IDocumentService
{
    Task<CreateDocumentResponseModel> CreateAsync(CreateDocumentModel createDocumentModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<DocumentResponseModel>> GetAllByPersonId(Guid id);
}
