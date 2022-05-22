using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;
using MyWebShop.Infrastructure.Data.Repositories;

namespace MyWebShop.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfContext _context;
    
    public UnitOfWork(EfContext context)
    {
        _context = context;
    }
    
    public IProductRepository ProductRepository => new ProductRepository(_context);
    public Repository<User> UserRepository => new UserRepository(_context);
    public Repository<Order> OrderRepository => new OrderRepository(_context);

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}