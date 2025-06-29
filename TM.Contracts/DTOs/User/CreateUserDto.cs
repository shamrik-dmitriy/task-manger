namespace TM.Contracts.DTOs.User;

public class CreateUserDto
{
    /// <summary>
    /// Псевдоним
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Подтверждение пароля
    /// </summary>
    public string ConfirmPassword { get; set; }
}