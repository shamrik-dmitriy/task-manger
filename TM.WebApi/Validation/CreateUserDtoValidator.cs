using FluentValidation;
using TM.Contracts.DTOs.User;

namespace TM.WebApi.Validation;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Электронная почта обязательна");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Имя пользователя обязательно");
        
        RuleFor(x=>x.Password)
            .Equal(x=>x.ConfirmPassword)
            .WithMessage("Пароль и подтверждение не совпадают");
    }
}