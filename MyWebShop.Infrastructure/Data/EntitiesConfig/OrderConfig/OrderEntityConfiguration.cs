using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig.OrderConfig;

public class OrderEntityConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.ToTable("order");
        
        builder.Property(order => order.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(order => order.TotalPrice)
            .HasColumnName("total_price")
            .IsRequired();
        
        // builder.Property(order => order.Status)
        //     .HasColumnName("status")
        //     .IsRequired();

        builder.HasMany(order => order.OrderItems)
            .WithOne(orderItem => orderItem.Order)
            .HasForeignKey(orderItem => orderItem.OrderId);
    }
}