using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Contracts.DTOs.User;

namespace TM.Application.Interfaces;

public interface IUserService
{
    public Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);

    Task<UserDto?> GetUserByIdAsync(Guid id);
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task DeleteUserAsync(Guid id);
    Task DeactivateUserAsync(Guid id);
    Task ActivateUserAsync(Guid id);
}