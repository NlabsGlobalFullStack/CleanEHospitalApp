using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.CreateDepartment;
public sealed record CreateDepartmentCommand(
    string Name,
    string? Description
) : IRequest<Result<string>>;
