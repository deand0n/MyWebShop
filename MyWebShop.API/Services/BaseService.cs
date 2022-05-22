using MyWebShop.Domain.Interfaces;

namespace MyWebShop.Services;

public class BaseService
{
    protected IUnitOfWork UnitOfWork { get; }

    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}