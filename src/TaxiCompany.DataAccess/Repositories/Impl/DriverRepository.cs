using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class DriverRepository : BaseRepository<Driver>, IDriverRepository
{
    public DriverRepository(DatabaseContext context) : base(context) { }
}
