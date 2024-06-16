using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Auth.ForgotPasswordEmail;
public sealed record ForgotPasswordEmailCommand(
    string UserNameOrEmail
) : IRequest<Result<string>>;
