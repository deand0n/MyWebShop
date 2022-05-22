using MyWebShop.Domain.Models;

namespace MyWebShop.DTOs.Response;

public class ProductDtoResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<Image> Images { get; set; }
    public List<Comment> Comments { get; set; }
}