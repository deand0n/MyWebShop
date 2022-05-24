namespace MyWebShop.DTOs.Request;

public class UserDtoRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool isAdmin { get; set; }
}