using System.Linq.Expressions;

namespace MyWebShop.Domain.Interfaces;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
    Task<int> CountAsync(Expression<Func<T, bool>> expression); 
}