using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(DatabaseContext context) : base(context) { }
}
