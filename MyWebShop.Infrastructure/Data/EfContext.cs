using Microsoft.EntityFrameworkCore;
using MyWebShop.Domain.Base;
using MyWebShop.Domain.Models;
using MyWebShop.Infrastructure.Data.EntitiesConfig.OrderConfig;
using MyWebShop.Infrastructure.Data.EntitiesConfig.ProductConfig;
using MyWebShop.Infrastructure.Data.EntitiesConfig.UserConfig;

namespace MyWebShop.Infrastructure.Data;

public sealed class EfContext : DbContext
{
    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        CheckEntityState();
        
        return base.SaveChangesAsync(cancellationToken);        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=my_web_shop;Username=student;Password=admin");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        new ProductEntityConfiguration().Configure(modelBuilder.Entity<Product>());
        new ImageEntityConfiguration().Configure(modelBuilder.Entity<Image>());
        new CommentEntityConfiguration().Configure(modelBuilder.Entity<Comment>());
        
        new OrderEntityConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderItemEntityConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        
        new UserEntityConfiguration().Configure(modelBuilder.Entity<User>());
    }

    private void CheckEntityState()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var baseEntity = entry.Entity as IBaseEntity;
            if (baseEntity == null)
            {
                continue;
            }
            
            if (entry.State == EntityState.Added)
            {
                baseEntity.Id = Guid.NewGuid();
                baseEntity.CreateDate = DateTime.UtcNow;
                baseEntity.UpdateDate = baseEntity.CreateDate;
                baseEntity.DeleteDate = null;
                baseEntity.IsDeleted = false;
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdateDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.UpdateDate = DateTime.UtcNow;
                baseEntity.DeleteDate = DateTime.UtcNow;
                baseEntity.IsDeleted = true;
            }
        }
    }
}