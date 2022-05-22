using System.Linq.Expressions;
using AutoMapper;
using MyWebShop.Domain.Base.Pagination;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Request;
using MyWebShop.DTOs.Response;

namespace MyWebShop.Services;

public class ProductsService : BaseService
{
    private readonly IProductRepository _productRepository;

    public ProductsService(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
        _productRepository = unitOfWork.ProductRepository;
    }
    
    public async Task<ProductDtoResponse> AddAsync(ProductDtoRequest request)
    {
        var images = Mapper.Map<List<ImageDtoRequest>, List<Image>>(request.Images);

        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity,
            Images = images ?? new List<Image>(),
        };
        
        await _productRepository.AddAsync(product);
        await UnitOfWork.SaveChangesAsync();

        var response = Mapper.Map<Product, ProductDtoResponse>(product);

        return response;
    }

    public async Task<Page<ProductDtoResponse>> GetPaginatedListAsync(Pageable request)
    {
        var searchQuery = request.SearchQuery.Trim().ToLower();
        
        Expression<Func<Product, bool>> closestToSearchQuery = product => 
            product.Name.Contains(searchQuery) || 
            product.Description.Contains(searchQuery);
        
        var products = await _productRepository.PaginatedListAsync(closestToSearchQuery, request);
        
        var response = Mapper.Map<List<Product>, List<ProductDtoResponse>>(products);
        
        return new Page<ProductDtoResponse>(response ?? new List<ProductDtoResponse>(), products.Count, request);
    }
    
    public async Task<ProductDtoResponse?> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }

        var response = Mapper.Map<Product, ProductDtoResponse>(product);

        return response;
    }

    public async Task<ProductDtoResponse?> UpdateAsync(Product productRequest, Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }

        product.Name = productRequest.Name;
        product.Name = productRequest.Name;
        product.Description = productRequest.Description;
        product.Price = productRequest.Price;
        product.Quantity = productRequest.Quantity;
        product.Images = productRequest.Images;
        product.Comments = productRequest.Comments;
        
        await _productRepository.UpdateAsync(product);
        await UnitOfWork.SaveChangesAsync();
        
        var response = Mapper.Map<Product, ProductDtoResponse>(product);

        return response;
    }

    public async Task<bool?> DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }
        
        bool response = await _productRepository.DeleteAsync(product);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
}