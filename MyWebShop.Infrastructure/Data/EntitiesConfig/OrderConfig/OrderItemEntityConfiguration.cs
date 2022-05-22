using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig.OrderConfig;

public class OrderItemEntityConfiguration : BaseEntityConfiguration<OrderItem>
{
    public override void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("order_item");
        
        builder.Property(orderItem => orderItem.Quantity)
            .HasColumnName("quantity")
            .IsRequired();
        
        builder.Property(orderItem => orderItem.UnitPrice)
            .HasColumnName("unit_price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(orderItem => orderItem.TotalPrice)
            .HasColumnName("total_price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(orderItem => orderItem.OrderId)
            .HasColumnName("order_id")
            .IsRequired();
        
        builder.Property(orderItem => orderItem.ProductId)
            .HasColumnName("product_id")
            .IsRequired();
    }
}