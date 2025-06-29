using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.Application.Interfaces;
using TM.Contracts.DTOs.Task;

namespace TM.Application.Services;

public class TaskService : ITaskService
{
    public Task<TaskDto> CreateAsync(TaskDto taskDto)
    {
        throw new NotImplementedException();
    }

    public Task<TaskDto> UpdateAsync(TaskDto taskDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TaskDto taskDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TaskDto> GetAsync(long id)
    {
        throw new NotImplementedException();
    }
}