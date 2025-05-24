using System;

namespace TM.Domain.Entities.Task;

public class Task : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public Guid UserId { get; set; }
    public User.User User { get; set; }
    
    public Guid TaskTypeId { get; set; }
    public TaskType TaskType { get; set; }    
    
    public Guid TaskStatusId { get; set; }
    public TaskStatus TaskStatus { get; set; }
}