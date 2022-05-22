using AutoMapper;
using MyWebShop.Domain.Interfaces;

namespace MyWebShop.Services;

public class BaseService
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}