using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.GetAllUsers;
public sealed record GetAllUsersQuery(
    int PageNumber = 1,
    int PageSize = 4,
    string Search = ""
) : IRequest<Result<IList<GetAllUsersQueryResponse>>>;
