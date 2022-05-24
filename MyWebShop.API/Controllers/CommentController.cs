using Microsoft.AspNetCore.Mvc;
using MyWebShop.DTOs.Request;
using MyWebShop.Services;

namespace MyWebShop.Controllers;

[Route("api/[controller]")]
public class CommentController : BaseApiController
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CommentDtoRequest request)
    {
        var comment = await _commentService.Create(request);
        return Ok(comment);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] CommentDtoRequest request)
    {
        var comment = await _commentService.Edit(id, request);

        if (comment is null)
        {
            return NotFound();
        }

        return Ok(comment);
    }
}