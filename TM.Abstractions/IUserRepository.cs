using TM.Domain.Entities.User;

namespace TM.Abstractions;

public interface IUserRepository
{
    public Task AddAsync(User user);

    public Task UpdateUser(User user);

    public Task DeleteUser(User user);

    public Task<User?> GetUser(User user);

    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User?> GetUserByEmail(string userEmail);
}