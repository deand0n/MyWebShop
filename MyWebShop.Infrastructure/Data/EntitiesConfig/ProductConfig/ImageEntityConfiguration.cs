using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

public class ImageEntityConfiguration : BaseEntityConfiguration<Image>
{
    public override void Configure(EntityTypeBuilder<Image> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("image");

        builder.Property(image => image.RawBase64)
            .HasColumnName("url")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(image => image.Title)
            .HasColumnName("alt")
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(image => image.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
    }
}