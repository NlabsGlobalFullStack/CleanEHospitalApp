using FluentValidation;

namespace eHospitalServer.Application.Features.Auth.ChangePasswordWithForgotPasswordCode;

public class ChangePasswordWithForgotPasswordCodeCommandValidator : AbstractValidator<ChangePasswordWithForgotPasswordCodeCommand>
{
    public ChangePasswordWithForgotPasswordCodeCommandValidator()
    {
        RuleFor(p => p.ForgotPasswordCode)
            .NotEmpty().NotNull().WithMessage("Forgot Password Code cannot be empty.")
            .GreaterThan(6).WithMessage("Forgot Password Code must be greater than 6.");

        RuleFor(p => p.NewPassword)
            .NotEmpty()
            .NotNull()
            .WithMessage("Password cannot be empty!");

        RuleFor(p => p.NewPassword)
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters!");

        RuleFor(p => p.NewPassword)
            .Matches("[A-Z]")
            .WithMessage("The password must contain at least 1 uppercase letter!");

        RuleFor(p => p.NewPassword)
            .Matches("[a-z]")
            .WithMessage("The password must contain at least 1 lowercase letter!");

        RuleFor(p => p.NewPassword)
            .Matches("[0-9]")
            .WithMessage("The password must contain at least 1 number!");

        RuleFor(p => p.NewPassword)
            .Matches("[^a-zA-Z0-9]")
            .WithMessage("The password must contain at least 1 special character!");

        RuleFor(p => p.ReNewPassword)
            .Equal(p => p.NewPassword).WithMessage("Passwords must match.");
    }
}