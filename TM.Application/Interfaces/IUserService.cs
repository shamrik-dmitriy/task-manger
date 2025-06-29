using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Contracts.DTOs.User;

namespace TM.Application.Interfaces;

public interface IUserService
{
    public Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);

    Task<UserDto> GetUserAsync(Guid id);
    Task<IEnumerable<UserDto>> GetUsersAsync();
}