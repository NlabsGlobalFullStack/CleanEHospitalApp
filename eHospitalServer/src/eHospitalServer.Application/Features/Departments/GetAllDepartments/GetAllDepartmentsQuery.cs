using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Departments.GetAllDepartments;
public sealed record GetAllDepartmentsQuery : IRequest<Result<List<DepartmentResponse>>>;
