using System.Collections.Generic;
using TM.Domain.Entities.Task;

namespace TM.Domain.Entities.User;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public byte[] Password { get; set; }

    public byte[] Salt { get; set; }

    public bool IsActive { get; set; }
    
    public ICollection<Task.Task>? Tasks { get; set; }
    public ICollection<TaskStatus>? TaskStatuses  { get; set; }
    public ICollection<TaskType>? Tasktypes { get; set; }
    
    public ICollection<Category.Category>? Сategories { get; set; }
}