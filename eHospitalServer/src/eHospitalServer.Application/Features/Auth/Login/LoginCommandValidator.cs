using FluentValidation;

namespace eHospitalServer.Application.Features.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.IdentityNumberOrUserNameOrEmail).NotEmpty().NotNull().WithMessage("IdentityNumber Or UserName Or Email cannot be empty!");
        RuleFor(p => p.Password).NotEmpty().NotNull().WithMessage("Password cannot be empty!");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("The password must contain at least 1 uppercase letter!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("The password must contain at least 1 lowercase letter!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("The password must contain at least 1 number!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("The password must contain at least 1 special character!");
    }
}