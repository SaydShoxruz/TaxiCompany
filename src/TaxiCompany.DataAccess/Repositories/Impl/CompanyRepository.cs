using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(DatabaseContext context) : base(context) { }
}
