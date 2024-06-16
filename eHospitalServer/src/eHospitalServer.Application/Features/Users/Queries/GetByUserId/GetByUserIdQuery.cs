using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.GetByUserId;
public sealed record GetByUserIdQuery(string Id) : IRequest<Result<UserResponse>>;
