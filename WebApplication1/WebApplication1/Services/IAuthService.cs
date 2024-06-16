using WebApplication1.DTO;
using LoginRequest = WebApplication1.DTO.LoginRequest;

namespace WebApplication1.Services;

public interface IAuthService
{
    Task<TokenResponse> Authenticate(LoginRequest request);
    Task<TokenResponse> RefreshToken(RefreshTokenRequest request);
}