using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(DatabaseContext context) : base(context) { }
}
