using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Roles.RoleSync;
public sealed record RoleSyncCommand() : IRequest<Result<string>>;
