using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CarsOwnerRepository : BaseRepository<CarsOwner>, ICarsOwnerRepository
{
    public CarsOwnerRepository(DatabaseContext context) : base(context) { }
}
