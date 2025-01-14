using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class InsuranceRepository : BaseRepository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(DatabaseContext context) : base(context) { }
}
