using System.Linq.Expressions;
using AutoMapper;
using MyWebShop.Domain.Base.Pagination;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Request;

namespace MyWebShop.Services;

public class ProductService : BaseService
{
    public ProductService(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    { }
    
    public async Task<Product> AddAsync(ProductDtoRequest request)
    {
        var images = Mapper.Map<List<ImageDtoRequest>, List<Image>>(request.Images);

        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity,
            Images = images ?? new List<Image>(),
            UserId = request.UserId,
        };
        
        var response = await UnitOfWork.ProductRepository.AddAsync(product);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }

    public async Task<Page<Product>> GetPaginatedListAsync(Pageable request)
    {
        var searchQuery = request.SearchQuery.Trim().ToLower();
        
        Expression<Func<Product, bool>> closestToSearchQuery = product => 
            product.Name.Contains(searchQuery) || 
            product.Description.Contains(searchQuery);
        
        var products = await UnitOfWork.ProductRepository.PaginatedListAsync(closestToSearchQuery, request);

        return new Page<Product>(products, products.Count, request);
    }
    
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await UnitOfWork.ProductRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }

        return product;
    }

    public async Task<Product?> UpdateAsync(Product productRequest, Guid id)
    {
        var product = await UnitOfWork.ProductRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }

        product.Name = productRequest.Name;
        product.Description = productRequest.Description;
        product.Price = productRequest.Price;
        product.Quantity = productRequest.Quantity;
        product.Images = productRequest.Images;
        product.Comments = productRequest.Comments;
        
        var response = await UnitOfWork.ProductRepository.UpdateAsync(product);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }

    public async Task<bool?> DeleteAsync(Guid id)
    {
        var product = await UnitOfWork.ProductRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }
        
        var response = await UnitOfWork.ProductRepository.DeleteAsync(product);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
}