using AutoMapper;
using MyWebShop.Domain.Interfaces;
using MyWebShop.Domain.Models;
using MyWebShop.DTOs.Request;

namespace MyWebShop.Services;

public class UserService : BaseService
{
    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    { }

    public async Task<User> CreateAsync(UserDtoRequest request)
    {
        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            IsAdmin = request.isAdmin,
        };
        
        var response = await UnitOfWork.UserRepository.AddAsync(user);
        await UnitOfWork.SaveChangesAsync();
        
        return response;
    }
    
    public async Task<User?> LoginAsync(UserDtoRequest request)
    {
        var user = await UnitOfWork.UserRepository.GetByEmailAsync(request.Email);
        if (user is null || user.Password != request.Password)
        {
            return null;
        }
        
        return user;
    }
}