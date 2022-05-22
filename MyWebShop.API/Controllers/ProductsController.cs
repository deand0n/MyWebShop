using Microsoft.AspNetCore.Mvc;
using MyWebShop.Domain.Base.Pagination;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Request;
using MyWebShop.Services;

namespace MyWebShop.Controllers;

[Route("api/[controller]")]
public class ProductsController : BaseApiController
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductDtoRequest request)
    {
        var product = await _productsService.AddAsync(request);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedList([FromQuery] Pageable request)
    {
        var products = await _productsService.GetPaginatedListAsync(request);
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var product = await _productsService.GetByIdAsync(id);

        if (product is null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] Product request, [FromRoute] Guid id)
    {
        var product = await _productsService.UpdateAsync(request, id);
        
        if (product is null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var response = await _productsService.DeleteAsync(id);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}