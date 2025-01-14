using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(DatabaseContext context) : base(context) { }
}
