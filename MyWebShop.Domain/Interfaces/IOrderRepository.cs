using MyWebShop.Domain.Models;

namespace MyWebShop.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetOrdersByUser(Guid userId);
}