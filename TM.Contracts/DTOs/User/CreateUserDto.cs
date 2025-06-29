using System.ComponentModel.DataAnnotations;

namespace TM.Contracts.DTOs.User;

/// <summary>
/// DTO для создания пользователя
/// </summary>
public class CreateUserDto
{
    /// <summary>
    /// Псевдоним
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Имя пользователя обязательно"), MinLength(3), MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Адрес электронной почты
    /// </summary>
   [Required(AllowEmptyStrings = false, ErrorMessage = "Адрес электронной почты обязателен"), MinLength(10), MaxLength(100)]
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    [Required(AllowEmptyStrings = false), MinLength(8), MaxLength(100)]
    public string Password { get; set; }

    /// <summary>
    /// Подтверждение пароля
    /// </summary>
    [Required(AllowEmptyStrings = false), MinLength(8), MaxLength(100)]
    public string ConfirmPassword { get; set; }
}