using System;
using TM.Contracts.DTOs.User;
using TM.Domain.Entities.User;

namespace TM.Application.Extensions;

public static class UserMappingExtensions
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name
        };
    }
}