using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.Repositories;

public class OrderRepository : Repository<Order>
{
    public OrderRepository(DbContext context) : base(context)
    {
    }
}