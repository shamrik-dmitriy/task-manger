namespace TM.Domain.Entities.Category;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Task> Tasks { get; set; }
}