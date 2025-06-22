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
    /// Получить пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userService.GetUserAsync(id);
        return user is null ? NotFound() : Ok(user);
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userService.GetUsersAsync();
        return user is null ? NotFound() : Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateUserDto userDto)
    {
        var createdUser = await _userService.CreateUserAsync(userDto);
        return Ok(createdUser);
    }
}