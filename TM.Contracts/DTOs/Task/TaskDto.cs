using TaskStatus = TM.Domain.Entities.Task.TaskStatus;

namespace TM.Contracts.DTOs.Task;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public TaskStatus Status { get; set; }

    //public TaskType Type { get; set; }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid TaskTypeId { get; set; }
}