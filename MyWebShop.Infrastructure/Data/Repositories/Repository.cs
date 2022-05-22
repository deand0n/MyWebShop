using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Base;
using MyWebShop.Domain.Interfaces;

namespace MyWebShop.Infrastructure.Data.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class, IBaseEntity
{
    protected readonly DbSet<T> DbSet;
    
    protected Repository(DbContext context)
    {
        DbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public Task<T> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.SingleOrDefaultAsync(entity => entity.Id == id);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return DbSet.Where(expression).ToListAsync();
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return DbSet.CountAsync(expression);
    }
}