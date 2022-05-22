namespace MyWebShop.DTOs.Request;

public class ProductDtoRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<ImageDtoRequest> Images { get; set; }
}