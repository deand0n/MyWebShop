using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}