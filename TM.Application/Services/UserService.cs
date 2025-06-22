using System.Security.Cryptography;
using System.Text;
using TM.Abstractions;
using TM.Application.Interfaces;
using TM.Contracts.DTOs.User;
using TM.Domain.Entities.User;

namespace TM.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserDto> GetUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select<User, UserDto>(x => new UserDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email
        });
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var salt = GenerateSalt();
        var password = HashPassword(createUserDto.Password, salt);

        var user = await _userRepository.GetUserByEmail(createUserDto.Email);
        if (user is not null)
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email };
        
        var newUser = new User(createUserDto.Name, createUserDto.Email, password, salt);
        
        await _userRepository.AddAsync(newUser);
        return new UserDto { Id = newUser.Id, Name = newUser.Name, Email = newUser.Email };
    }

    private byte[] GenerateSalt()
    {
        var salt = new byte[32];
        using var rnd = RandomNumberGenerator.Create();
        rnd.GetBytes(salt);
        return salt;
    }

    private byte[] HashPassword(string password, byte[] salt)
    {
        using var sha256 = SHA256.Create();
        var combined = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        return sha256.ComputeHash(combined);
    }
}