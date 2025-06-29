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
        var user = await _userService.GetUserByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    /// <summary>
    /// Возвращает пользователя по адресу электронной почты
    /// </summary>
    /// <param name="email">Идентификатор пользователя</param>
    /// <returns>Пользователь с идентификатором <see cref="email"/></returns>
    [HttpGet("{email}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
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

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    /// <param name="userDto">DTO с данными пользователя</param>
    /// <exception cref="ConflictException">Если пользователь уже существует</exception>
    /// <returns>Созданный пользователь</returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
    {
        var createdUser = await _userService.CreateUserAsync(userDto);
        return Ok(createdUser);
    }

    /// <summary>
    /// Удаляет пользователя по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Деактивация пользователя
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    [HttpPatch("{id}/deactivate")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        await _userService.DeactivateUserAsync(id);
        return NoContent();
    }
    
    /// <summary>
    /// Активация пользователя
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    [HttpPatch("{id}/activate")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Activate(Guid id)
    {
        await _userService.ActivateUserAsync(id);
        return NoContent();
    }
}