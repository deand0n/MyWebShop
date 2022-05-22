using MyWebShop.Domain.Interfaces;

namespace MyWebShop.Services;

public class UserService : BaseService
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}