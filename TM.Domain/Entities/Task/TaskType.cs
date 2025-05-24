using System;

namespace TM.Domain.Entities;

public class TaskType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}