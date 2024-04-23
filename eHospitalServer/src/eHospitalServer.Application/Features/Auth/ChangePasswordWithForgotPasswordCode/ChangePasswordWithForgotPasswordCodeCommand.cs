using eHospitalServer.Infrastructure.Results;
using FluentValidation;
using MediatR;

namespace eHospitalServer.Application.Features.Auth.ChangePasswordWithForgotPasswordCode;
public sealed record ChangePasswordWithForgotPasswordCodeCommand(
    int ForgotPasswordCode,
    string NewPassword,
    string ReNewPassword
) : IRequest<Result<string>>;


public sealed class ChangePasswordWithForgotPasswordCodeCommandValidator : AbstractValidator<ChangePasswordWithForgotPasswordCodeCommand>
{
    public ChangePasswordWithForgotPasswordCodeCommandValidator()
    {
        RuleFor(p => p.ForgotPasswordCode).NotEmpty();
    }
}