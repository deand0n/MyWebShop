using MyWebShop.Domain.Base;

namespace MyWebShop.Domain.Models;

public class Order : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
}