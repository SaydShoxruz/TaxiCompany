using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(DatabaseContext context) : base(context) { }
}
