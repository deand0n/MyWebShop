using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return DbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
}