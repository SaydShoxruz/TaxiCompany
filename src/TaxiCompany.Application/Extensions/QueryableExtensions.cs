using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Common;

namespace TaxiCompany.Application.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, PaginationParam options) where T : BaseEntity
    {
        if (options.Index < 1)
            options.Index = 1;

        if (options.Size < 1)
            options.Size = 10;

        var totalCount = await query.CountAsync();

        var items = await query
           .Skip((options.Index - 1) * options.Size)
           .Take(options.Size)
           .ToListAsync();

        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            PageSize = options.Size,
            PageNumber = options.Index
        };
    }

    public static async Task<PagedResult<TEntityDTO>> ToPagedResultAsync<TEntity, TEntityDTO>(
        this IQueryable<TEntity> query,
        PaginationParam options,
        IMapper mapper) where TEntity : BaseEntity
    {
        if (options.Index < 1)
            options.Index = 1;

        if (options.Size < 1)
            options.Size = 10;

        var totalCount = await query.CountAsync();

        var items = await query
           .Skip((options.Index - 1) * options.Size)
           .Take(options.Size)
           .ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
           .ToListAsync();

        return new PagedResult<TEntityDTO>
        {
            Items = items,
            TotalCount = totalCount,
            PageSize = options.Size,
            PageNumber = options.Index
        };
    }
}
