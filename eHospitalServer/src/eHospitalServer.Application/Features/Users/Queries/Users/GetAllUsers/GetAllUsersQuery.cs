using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.Users.GetAllUsers;
public sealed record GetAllUsersQuery : IRequest<Result<List<GetAllUsersQueryResponse>>>;
