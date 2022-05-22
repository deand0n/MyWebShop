using MyWebShop.Domain.Base;

namespace MyWebShop.Domain.Models;

public class Product : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<Image> Images { get; set; }
    public List<Comment> Comments { get; set; }
}