using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.GetByIdDepartment;
public sealed record GetByIdDepartmentCommand(string Id) : IRequest<Result<DepartmentResponse>>;
