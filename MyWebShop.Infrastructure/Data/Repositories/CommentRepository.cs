using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(DbContext context) : base(context)
    {
    }
}