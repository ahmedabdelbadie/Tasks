using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DAL.DataContext;
using Task.PersonAddress.DAL.Repositories.IRepositories;

namespace Task.PersonAddress.DAL.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;
    public GenericRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _aspNetCoreNTierDbContext.AddAsync(entity);
        await _aspNetCoreNTierDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
    {
        await _aspNetCoreNTierDbContext.AddRangeAsync(entity);
        await _aspNetCoreNTierDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        _ = _aspNetCoreNTierDbContext.Remove(entity);
        return await _aspNetCoreNTierDbContext.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await _aspNetCoreNTierDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        return await (filter == null ? _aspNetCoreNTierDbContext.Set<TEntity>().ToListAsync(cancellationToken) : _aspNetCoreNTierDbContext.Set<TEntity>().Where(filter).ToListAsync(cancellationToken));
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _ = _aspNetCoreNTierDbContext.Update(entity);
        await _aspNetCoreNTierDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entity)
    {
        _aspNetCoreNTierDbContext.UpdateRange(entity);
        await _aspNetCoreNTierDbContext.SaveChangesAsync();
        return entity;
    }
}