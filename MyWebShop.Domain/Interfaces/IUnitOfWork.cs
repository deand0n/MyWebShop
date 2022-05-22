namespace MyWebShop.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    Task<bool> SaveChangesAsync();
}