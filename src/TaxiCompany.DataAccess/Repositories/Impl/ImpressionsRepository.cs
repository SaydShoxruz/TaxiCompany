using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class ImpressionsRepository : BaseRepository<Impressions>, IImpressionsRepository
{
    public ImpressionsRepository(DatabaseContext context) : base(context) { }
}
