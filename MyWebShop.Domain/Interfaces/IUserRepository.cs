using MyWebShop.Domain.Models;

namespace MyWebShop.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}