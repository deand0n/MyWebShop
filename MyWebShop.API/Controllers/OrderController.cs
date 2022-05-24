using Microsoft.AspNetCore.Mvc;
using MyWebShop.DTOs.Request;
using MyWebShop.Services;

namespace MyWebShop.Controllers;

[Route("api/[controller]")]
public class OrderController : BaseApiController
{
    private readonly OrderService _orderService;
    
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDtoRequest request)
    {
        var order = await _orderService.CreateOrderAsync(request);
        return Ok(order);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByUserId([FromRoute] Guid id)
    {
        var orders = await _orderService.GetOrdersByUser(id);
        return Ok(orders);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] OrderDtoRequest request)
    {
        var order = await _orderService.UpdateOrderAsync(id, request);
        
        if (order is null)
        {
            return NotFound();
        }
        
        return Ok(order);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
    {
        var isDeleted = await _orderService.DeleteOrderAsync(id);
        
        if (isDeleted is null)
        {
            return NotFound();
        }
        
        return Ok(isDeleted);
    }
}