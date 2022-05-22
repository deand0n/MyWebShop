using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

public class ProductEntityConfiguration : BaseEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("product");
        
        builder.Property(product => product.Name) 
            .HasColumnName("name")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasColumnName("description")
            .HasMaxLength(500);
        
        builder.Property(product => product.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(product => product.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.HasMany(product => product.Images)
            .WithOne(image => image.Product)
            .HasForeignKey(image => image.ProductId);

        builder.HasMany(product => product.Comments)
            .WithOne(comment => comment.Product)
            .HasForeignKey(comment => comment.ProductId);
    }
}