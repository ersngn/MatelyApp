using System.Linq.Expressions;
using Mately.Common.Domain.Models.Base.Mongo;

namespace Mately.Service.Match.Repository.MongoBase;

public interface IRepository<T> where T : MongoEntity, new()
{
    IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
    Task<T> GetByIdAsync(string Id);
    Task<T> AddAsync(T entity);
    Task<bool> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(string id, T entity);
    Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
    Task<T> DeleteAsync(T entity);
    Task<T> DeleteAsync(string id);
    Task<T> DeleteAsync(Expression<Func<T, bool>> filter);
}