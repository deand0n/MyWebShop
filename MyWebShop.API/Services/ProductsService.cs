using System.Linq.Expressions;
using ImgurSharp;
using MyWebShop.Domain.Base.Pagination;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;

namespace MyWebShop.Services;

public class ProductsService : BaseService
{
    private readonly IProductRepository _productRepository;

    public ProductsService(
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _productRepository = unitOfWork.ProductRepository;
    }
    
    public async Task<Product> AddAsync(Product productRequest)
    {
        // Imgur imgur = new Imgur("dccd8529c8cd2ae");
        // IFormFile
        //
        // var image = await imgur.UpdateImageAnonymous()


        var product = new Product()
        {
            Name = productRequest.Name,
            Description = productRequest.Description,
            Price = productRequest.Price,
            Quantity = productRequest.Quantity,
            Images = productRequest.Images,
            Comments = productRequest.Comments,
        };
        
        await _productRepository.AddAsync(product);
        await UnitOfWork.SaveChangesAsync();

        return product;
    }

    public async Task<Page<Product>> GetPaginatedListAsync(Pageable request)
    {
        var searchQuery = request.SearchQuery.Trim().ToLower();
        
        Expression<Func<Product, bool>> closestToSearchQuery = product => 
            product.Name.Contains(searchQuery) || 
            product.Description.Contains(searchQuery);
        
        var products = await _productRepository.PaginatedListAsync(closestToSearchQuery, request);
        
        return new Page<Product>(products, products.Count, request);
    }
    
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        return product;
    }

    public async Task<Product?> UpdateAsync(Product productRequest, Guid id)
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

        return product;
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