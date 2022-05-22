using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.Domain.Base;

namespace MyWebShop.Infrastructure.Data.EntitiesConfig;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> 
    where T : class, IBaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(entity => !entity.IsDeleted);
        
        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(entity => entity.CreateDate)
            .HasColumnName("create_date")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        
        builder.Property(entity => entity.UpdateDate)
            .HasColumnName("update_date")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(entity => entity.DeleteDate)
            .HasColumnName("delete_date")
            .HasColumnType("timestamp with time zone");

        builder.Property(entity => entity.IsDeleted)
            .HasColumnName("is_deleted")
            .HasColumnType("boolean")
            .IsRequired();
    }
}