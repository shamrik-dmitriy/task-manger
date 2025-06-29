using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM.Abstractions;
using TM.Application.Exceptions;
using TM.Application.Extensions;
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

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        return user?.ToUserDto();
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        return user?.ToUserDto();
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(x => x.ToUserDto());
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user is null)
            throw new NotFoundException("User not found");

        await _userRepository.DeleteUser(user);
    }

    public async Task DeactivateUserAsync(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user is null)
            throw new NotFoundException("User not found");

        user.Deactivate();
        await _userRepository.UpdateUser(user);
    }

    public async Task ActivateUserAsync(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user is null)
            throw new NotFoundException("User not found");

        user.Activate();
        await _userRepository.UpdateUser(user);
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

        return newUser.ToUserDto();
    }
}