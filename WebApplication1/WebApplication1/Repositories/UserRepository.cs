using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly HospitalDbContext _context;
    
    public UserRepository(HospitalDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserByUsername(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User> GetUserByRefreshToken(string refreshToken)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.RefreshToken == refreshToken);
    }

    public async Task AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}