using AutoMapper;
using MyWebShop.Domain.Interfaces;

namespace MyWebShop.Services;

public class UserService : BaseService
{
    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}