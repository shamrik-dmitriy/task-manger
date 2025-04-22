namespace TM.Domain.Entities.User;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsActive { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}