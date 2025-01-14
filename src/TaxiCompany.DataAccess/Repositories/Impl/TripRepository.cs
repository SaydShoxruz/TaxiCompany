using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class TripRepository : BaseRepository<Trip>, ITripRepository
{
    public TripRepository(DatabaseContext context) : base(context) { }
}
