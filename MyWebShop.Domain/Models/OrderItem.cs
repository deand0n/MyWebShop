using MyWebShop.Domain.Base;

namespace MyWebShop.Domain.Models;

public class OrderItem : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}