using TM.Application.DTO;

namespace TM.Application.Interfaces;

public interface ITaskService
{
    public Task<TaskDto> CreateAsync(TaskDto taskDto);
    public Task<TaskDto> UpdateAsync(TaskDto taskDto);
    public Task DeleteAsync(TaskDto taskDto);
    public Task<List<TaskDto>> GetAllAsync();
    public Task<TaskDto> GetAsync(long id);
}