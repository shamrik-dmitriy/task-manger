using Microsoft.EntityFrameworkCore;
using TM.Abstractions;
using TM.Domain.Entities.User;
using TM.Persistance;

namespace TM.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUser(User user)
    {
        var findUser = await _context.Users.FindAsync(user);
        return findUser;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        return users.AsReadOnly();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var findUser = await _context.Users.FindAsync(email);
        return findUser;
    }
}