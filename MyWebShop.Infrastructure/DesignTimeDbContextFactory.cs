using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyWebShop.Infrastructure.Data;

namespace MyWebShop.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EfContext> 
{ 
    public EfContext CreateDbContext(string[] args) 
    { 
        // IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build(); 
        var builder = new DbContextOptionsBuilder<EfContext>(); 
        // var connectionString = configuration.GetConnectionString("DatabaseConnection"); 
        // builder.UseSqlServer(connectionString); 
        
        return new EfContext(builder.Options); 
    } 
}