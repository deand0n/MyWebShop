using System.Linq.Expressions;
using MyWebShop.Domain.Base.Pagination;
using MyWebShop.Domain.Models;

namespace MyWebShop.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> PaginatedListAsync(Expression<Func<Product, bool>> expression, Pageable pageable);
}