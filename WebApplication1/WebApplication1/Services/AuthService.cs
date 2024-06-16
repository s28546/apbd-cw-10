using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

using WebApplication1.DTO;
using WebApplication1.Entities;
using WebApplication1.Repositories;
using WebApplication1.Utilities;

using LoginRequest = WebApplication1.DTO.LoginRequest;

namespace WebApplication1.Services;

using Microsoft.Extensions.Configuration;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<TokenResponse> Authenticate(LoginRequest request)
    {
        var user = await _userRepository.GetUserByUsername(request.Username);
        
        if (user == null || !PasswordUtils.VerifyPassword(request.Password, user.Password))
        {
            return null;
        }

        var tokenResponse = GenerateTokens(user);
        user.RefreshToken = tokenResponse.RefreshToken;
        
        await _userRepository.UpdateUser(user);

        return tokenResponse;
    }
    
    public async Task<TokenResponse> RefreshToken(RefreshTokenRequest request)
    {
        var user = await _userRepository.GetUserByRefreshToken(request.RefreshToken);
        
        if (user == null)
        {
            return null;
        }

        var tokenResponse = GenerateTokens(user);
        user.RefreshToken = tokenResponse.RefreshToken;
        
        await _userRepository.UpdateUser(user);

        return tokenResponse;
    }
    
    private TokenResponse GenerateTokens(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //jwt claimtypes
            Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.IDUser.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iss, "siema"),
                    new Claim(JwtRegisteredClaimNames.Aud, "localhost")
                }
            ),
            
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);
        var refreshToken = Guid.NewGuid().ToString();

        return new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}
