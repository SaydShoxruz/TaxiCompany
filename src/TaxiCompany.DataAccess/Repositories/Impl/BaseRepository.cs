using Microsoft.EntityFrameworkCore;
using TaxiCompany.Core.Common;
using TaxiCompany.Core.Exceptions;
using TaxiCompany.DataAccess.Persistence;
using System.Linq.Expressions;
using TaxiCompany.DataAccess.Repositories.Interfaces;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DatabaseContext _context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DatabaseContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }
    public async ValueTask<TEntity> InsertAsync(
        TEntity entity)
    {
        var entityEntry = await _context
            .AddAsync<TEntity>(entity);

        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public IQueryable<TEntity> SelectAll() =>
        _context.Set<TEntity>();

    public async ValueTask<TEntity> SelectByIdWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes = null)
    {
        IQueryable<TEntity> entities = this.SelectAll();

        foreach (var include in includes)
        {
            entities = entities.Include(include);
        }

        return await entities.FirstOrDefaultAsync(expression);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync();

        return addedEntity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await _context.SaveChangesAsync();

        return removedEntity;
    }

    public IEnumerable<TEntity> GetAllAsEnumurable()
    {
        return DbSet.AsEnumerable();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }
    public IQueryable<TEntity> GetAll() =>
        DbSet.AsQueryable();

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

        if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

        return await DbSet.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}
