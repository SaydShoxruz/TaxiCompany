using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(DatabaseContext context) : base(context) { }
}
