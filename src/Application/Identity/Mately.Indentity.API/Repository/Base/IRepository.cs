using System.Linq.Expressions;
using Mately.Common.Domain.Models.Base;

namespace Mately.Indentity.API.Repository.Base;

public interface IRepository<T> where T : class, IEntity, new()
{
    IQueryable<T> Get(Expression<Func<T, bool>>? filter=null);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task<bool> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}