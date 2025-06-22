using System;
using System.Collections.Generic;
using TM.Domain.Entities.Task;

namespace TM.Domain.Entities.User;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public byte[] Password { get; private set; }

    public byte[] Salt { get; private set; }

    public bool IsActive { get; private set; }
    
    public ICollection<Task.Task>? Tasks { get; private set; }
    public ICollection<TaskStatus>? TaskStatuses  { get; private set; }
    public ICollection<TaskType>? Tasktypes { get; private set; }
    
    public ICollection<Category.Category>? Сategories { get; private set; }

    public User(){}

    public User(string name, string email, byte[] password, byte[] salt)
    {
        Name = name;
        Email = email;
        Password = password;
        Salt = salt;
        IsActive = true;
    }
    
    public bool Deactivate() => IsActive = false;
}