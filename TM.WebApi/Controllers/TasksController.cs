using Microsoft.AspNetCore.Mvc;
using TM.Application.Interfaces;
using TM.Contracts.DTOs.Task;

namespace TM.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly ILogger<TasksController> _logger;

    public TasksController(
        ITaskService taskService,
        ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    /// <summary>
    ///     Получает список задач
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(new List<TaskDto>());
    }

    /// <summary>
    /// Получает задачу по её идентификатору
    /// </summary>
    /// <param name="id">Идентификатор задачи</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(long id)
    {
        var tasks = await _taskService.GetAsync(id);
        return Ok(new List<TaskDto>());
    }

    /// <summary>
    /// Создаёт задачу 
    /// </summary>
    /// <param name="taskDto">Данные для создания задачи</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] TaskDto taskDto)
    {
        var task = await _taskService.CreateAsync(taskDto);
        return Ok(task);
    }
}