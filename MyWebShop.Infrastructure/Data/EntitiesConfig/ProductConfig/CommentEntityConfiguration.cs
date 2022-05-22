using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

public class CommentEntityConfiguration : BaseEntityConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("comment");
        
        builder.Property(comment => comment.Content)
            .HasColumnName("content")
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(comment => comment.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
        
        builder.Property(comment => comment.UserId)
            .HasColumnName("user_id")
            .IsRequired();
    }
}