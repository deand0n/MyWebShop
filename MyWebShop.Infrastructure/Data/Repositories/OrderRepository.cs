using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetOrdersByUser(Guid userId)
    {
        return  await DbSet.Where(order => order.UserId == userId).ToListAsync();
    }
}