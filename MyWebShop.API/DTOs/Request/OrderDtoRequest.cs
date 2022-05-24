namespace MyWebShop.DTOs.Request;

public class OrderDtoRequest
{
    public Guid UserId { get; set; }
    public Dictionary<Guid, int> ProductsIdsAndQuantity { get; set; }
}