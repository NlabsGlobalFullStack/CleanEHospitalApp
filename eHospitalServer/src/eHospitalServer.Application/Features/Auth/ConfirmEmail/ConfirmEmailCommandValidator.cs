using FluentValidation;

namespace eHospitalServer.Application.Features.Auth.ConfirmEmail;

public sealed class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(p => p.EmailConfirmCode).NotEmpty().NotNull().WithMessage("Email Verification code cannot be empty!");
        RuleFor(p => p.EmailConfirmCode).GreaterThan(6).WithMessage("Email Verification code must be at least 6 characters!");
    }
}