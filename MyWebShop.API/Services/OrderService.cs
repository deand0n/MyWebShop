using AutoMapper;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Request;

namespace MyWebShop.Services;

public class OrderService : BaseService
{
    public OrderService(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    { }

    public async Task<Order> CreateOrderAsync(OrderDtoRequest request)
    {
        var orderItems = new List<OrderItem>();
        decimal orderTotalPrice = 0;
        
        foreach (var idAndQuantity in request.ProductsIdsAndQuantity)
        {
            var product = await UnitOfWork.ProductRepository.GetByIdAsync(idAndQuantity.Key);
            
            var totalPrice = product.Price * idAndQuantity.Value;
            orderTotalPrice += totalPrice;
            
            var orderItem = new OrderItem()
            {
                Quantity = idAndQuantity.Value,
                ProductId = product.Id,
                UnitPrice = product.Price,
                TotalPrice = totalPrice,
            };
            
            orderItems.Add(orderItem);
        }
        
        var order = new Order()
        {
            UserId = request.UserId,
            OrderItems = orderItems,
            TotalPrice = orderTotalPrice,
        };
        
        var response = await UnitOfWork.OrderRepository.AddAsync(order);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
    
    public async Task<List<Order>> GetOrdersByUser(Guid userId)
    {
        var orders = await UnitOfWork.OrderRepository.GetOrdersByUser(userId);
        return orders;
    }

    public async Task<Order?> UpdateOrderAsync(Guid orderId, OrderDtoRequest request)
    {
        var order = await UnitOfWork.OrderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            return null;
        }

        var orderItems = new List<OrderItem>();
        decimal orderTotalPrice = 0;
        
        foreach (var idAndQuantity in request.ProductsIdsAndQuantity)
        {
            var product = await UnitOfWork.ProductRepository.GetByIdAsync(idAndQuantity.Key);
            
            var totalPrice = product.Price * idAndQuantity.Value;
            orderTotalPrice += totalPrice;
            
            var orderItem = new OrderItem()
            {
                Quantity = idAndQuantity.Value,
                ProductId = product.Id,
                UnitPrice = product.Price,
                TotalPrice = totalPrice,
            };
            
            orderItems.Add(orderItem);
        }
        
        order.OrderItems = orderItems;
        order.TotalPrice = orderTotalPrice;
        
        var response = await UnitOfWork.OrderRepository.UpdateAsync(order);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
    
    public async Task<bool?> DeleteOrderAsync(Guid id)
    {
        var order = await UnitOfWork.OrderRepository.GetByIdAsync(id);
        if (order is null)
        {
            return null;
        }
        
        var response = await UnitOfWork.OrderRepository.DeleteAsync(order);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
}