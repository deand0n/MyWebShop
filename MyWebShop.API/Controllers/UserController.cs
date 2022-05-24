using Microsoft.AspNetCore.Mvc;
using MyWebShop.DTOs.Request;
using MyWebShop.Services;

namespace MyWebShop.Controllers;

[Route("api/[controller]")]
public class UserController : BaseApiController
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDtoRequest request)
    {
        var user = await _userService.CreateAsync(request);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDtoRequest request)
    {
        var user = await _userService.LoginAsync(request);
        return Ok(user);
    }
}