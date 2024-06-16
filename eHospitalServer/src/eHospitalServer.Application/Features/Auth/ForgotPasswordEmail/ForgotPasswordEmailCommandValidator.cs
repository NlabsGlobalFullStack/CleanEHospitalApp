using FluentValidation;

namespace eHospitalServer.Application.Features.Auth.ForgotPasswordEmail;

public sealed class ForgotPasswordEmailCommandValidator : AbstractValidator<ForgotPasswordEmailCommand>
{
    public ForgotPasswordEmailCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotNull().NotEmpty().WithMessage("UserName Or Email cannot be empty.");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(4).WithMessage("Username or Email must be at least 4 characters.");
    }
}