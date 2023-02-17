using System.Linq.Expressions;
using Mately.Common.Domain.Models.Base;
using Mately.Identity.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mately.Identity.API.Repository.Base;

public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    private readonly ApplicationDbContext _applicationDbContext;

    public EfCoreRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter=null)
    {
        var entities = filter == null
            ? _applicationDbContext.Set<TEntity>()
            : _applicationDbContext.Set<TEntity>().Where(filter);

        return entities;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return  await _applicationDbContext.Set<TEntity>().FindAsync(filter);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return filter == null
            ? await _applicationDbContext.Set<TEntity>().ToListAsync()
            : await _applicationDbContext.Set<TEntity>().Where(filter).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _applicationDbContext.Set<TEntity>().AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _applicationDbContext.Set<TEntity>().AddRangeAsync(entities); 
        await _applicationDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _applicationDbContext.Set<TEntity>().Remove(entity);
        await _applicationDbContext.SaveChangesAsync();
        return entity;
    }
}