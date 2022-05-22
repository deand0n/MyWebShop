using AutoMapper;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Response;

namespace MyWebShop.AutoMapperConfigurations;

public class AutoMapperConfiguration
{
    public MapperConfiguration Configure()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductDtoResponse>();
            // cfg.AddProfile<ProductProfile>();
        });
        
        return config;
    }
}