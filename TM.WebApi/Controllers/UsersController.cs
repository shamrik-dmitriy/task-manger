using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.Application.Interfaces;
using TM.Contracts.DTOs.User;

namespace TM.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Возвращает пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Пользователь с идентификатором <see cref="id"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userService.GetUserAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    /// <summary>
    /// Возвращает список существующих пользователей
    /// </summary>
    /// <returns>Существующие пользователи</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var user = await _userService.GetUsersAsync();
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
    {
        var createdUser = await _userService.CreateUserAsync(userDto);
        return Ok(createdUser);
    }
}