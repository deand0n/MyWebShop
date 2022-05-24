namespace MyWebShop.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    IUserRepository UserRepository { get; }
    IOrderRepository OrderRepository { get; }
    ICommentRepository CommentRepository { get; }
    Task<bool> SaveChangesAsync();
}