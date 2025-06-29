namespace TM.Contracts.DTOs.User;

public class UserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Псевдоним
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; set; }
}