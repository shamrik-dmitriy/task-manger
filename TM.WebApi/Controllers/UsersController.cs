using Microsoft.AspNetCore.Mvc;
using TM.Domain.Entities.User;

namespace TM.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    public UsersController()
    {
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