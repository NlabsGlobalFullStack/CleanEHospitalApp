using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Auth.ConfirmEmail;
public sealed record ConfirmEmailCommand(
    int EmailConfirmCode
) : IRequest<Result<string>>;
