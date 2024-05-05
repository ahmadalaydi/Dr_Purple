using Dr_Purple.Domain.Entities.Users;
using FluentValidation;

namespace Dr_Purple.Application.ValidationRules;
public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(p => p.UserName).NotEmpty().WithErrorCode("2020");
    }
}