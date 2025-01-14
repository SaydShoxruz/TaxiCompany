using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(DatabaseContext context) : base(context) { }
}
