using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Auth.ChangePasswordWithForgotPasswordCode;
public sealed record ChangePasswordWithForgotPasswordCodeCommand(
    int ForgotPasswordCode,
    string NewPassword,
    string ReNewPassword
) : IRequest<Result<string>>;
