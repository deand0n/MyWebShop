using MyWebShop.Domain.Base;

namespace MyWebShop.Domain.Models;

public class Comment : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string Content { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}