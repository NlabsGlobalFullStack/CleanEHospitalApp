using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.Nurses.GetAllNurses;
public sealed record GetAllNursesQuery : IRequest<Result<List<GetAllNursesQueryResponse>>>;
