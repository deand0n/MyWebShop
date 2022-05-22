using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Models;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig.UserConfig;

public class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("user");
        
        builder.Property(user => user.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(user => user.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(user => user.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(user => user.Password)
            .HasColumnName("password")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(user => user.Comments)
            .WithOne(comment => comment.User)
            .HasForeignKey(comment => comment.UserId);
        
        builder.HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .HasForeignKey(order => order.UserId);
    }
}