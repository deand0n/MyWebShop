using AutoMapper;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Request;

namespace MyWebShop.Services;

public class CommentService : BaseService
{
    public CommentService(
        IUnitOfWork unitOfWork, 
        IMapper mapper) : base(unitOfWork, mapper)
    { }
    
    public async Task<Comment> Create(CommentDtoRequest request)
    {
        var comment = new Comment()
        {
            Content = request.Content,
            ProductId = request.ProductId,
            UserId = request.UserId
        };
        
        
        var response = await UnitOfWork.CommentRepository.AddAsync(comment);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
    
    public async Task<Comment?> Edit(Guid id, CommentDtoRequest request)
    {
        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(id);
        if (comment is null)
        {
            return null;
        }

        comment.Content = request.Content;
        
        var response = await UnitOfWork.CommentRepository.UpdateAsync(comment);
        await UnitOfWork.SaveChangesAsync();

        return response;
    }
}