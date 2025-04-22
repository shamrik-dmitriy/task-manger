using Microsoft.AspNetCore.Mvc;
using TM.Domain.Entities.User;

namespace TM.WebApi.Controllers;

[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    public UsersController()
    {
    }

    public async Task<IActionResult> Create()
    {
        return Ok();
    }

    /// <summary>
    /// Получить пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<User> Get(string id)
    {
        return new User();
    }
}