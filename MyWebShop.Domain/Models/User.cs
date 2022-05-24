using MyWebShop.Domain.Base;

namespace MyWebShop.Domain.Models;

public class User : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Order> Orders { get; set; }
    public List<Product> Products { get; set; }
}