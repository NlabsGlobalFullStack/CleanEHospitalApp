using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.Employees.GetAllEmployees;
public sealed record GetAllEmployeesQuery : IRequest<Result<List<GetAllEmployeesQueryResponse>>>;
