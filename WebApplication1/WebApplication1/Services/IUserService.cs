using RegisterRequest = WebApplication1.DTO.RegisterRequest;

namespace WebApplication1.Services;

public interface IUserService 
{
    Task Register(RegisterRequest request);
}