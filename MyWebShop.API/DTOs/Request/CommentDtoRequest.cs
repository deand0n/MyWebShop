namespace MyWebShop.DTOs.Request;

public class CommentDtoRequest
{
    public string Content { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
}