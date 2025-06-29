using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM.Abstractions;
using TM.Application.Exceptions;
using TM.Application.Interfaces;
using TM.Application.Interfaces.Infrastructure;
using TM.Contracts.DTOs.User;
using TM.Domain.Entities.User;

namespace TM.Application.Services;

public class UserService : IUserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public UserService(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
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
        var salt = _passwordHasher.GenerateSalt();
        var password = _passwordHasher.HashPassword(createUserDto.Password, salt);

        var user = await _userRepository.GetUserByEmail(createUserDto.Email);
        if (user is not null)
            throw new ConflictException("User already exists");

        var newUser = new User(createUserDto.Name, createUserDto.Email, password, salt);
        
        await _userRepository.AddAsync(newUser);
        return new UserDto { Id = newUser.Id, Name = newUser.Name, Email = newUser.Email };
    }
}