using eHospitalServer.Domain.Repositories.Jwt;
using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string IdentityNumberOrUserNameOrEmail,
    string Password,
    bool RememberMe
) : IRequest<Result<LoginCommandResponse>>;
