using WebApplication1.Entities;
using WebApplication1.Repositories;
using WebApplication1.Utilities;

using RegisterRequest = WebApplication1.DTO.RegisterRequest;

namespace WebApplication1.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Register(RegisterRequest request)
    {
        var user = new User 
        { 
            Username = request.Username, 
            Password = PasswordUtils.HashPassword(request.Password) 
        };
        await _userRepository.AddUser(user);
    }
}
