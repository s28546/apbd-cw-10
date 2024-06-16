using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsername(string username);
    Task<User> GetUserByRefreshToken(string refreshToken);
    Task AddUser(User user);
    Task UpdateUser(User user);
}